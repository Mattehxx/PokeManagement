using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using PokeManagement.Models;
using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Auth;
using PokeManagementDAL.Managers;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration, IUnitOfWork unitOfWork, Mapper mapper) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IConfiguration _configuration = configuration;
        private readonly IUnitOfWork _unitOfWork = unitOfWork;
        private readonly Mapper _mapper = mapper;
        #region POST - (login and registration)
        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            ApplicationUser? user = await _userManager.FindByNameAsync(model.Username);
            
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized();

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.UserName),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
        };

            foreach (var userRole in userRoles)
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));


            var token = GetToken(authClaims);

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo,
                role = userRoles[0],
                username = model.Username,
                id = user.Id
            });
        }

        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status422UnprocessableEntity, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new()
            {
                Name = model.Username,
                Surname = model.Surname,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Customer))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Customer));

            if (await _roleManager.RoleExistsAsync(ApplicationRoles.Customer))
                await _userManager.AddToRoleAsync(user, ApplicationRoles.Customer);

            return Ok(new Response { Status = "Success", Message = "User created successfully!" });
        }
        //[Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost]
        [Route("register-operator")]
        public async Task<IActionResult> RegisterOperator([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new()
            {
                Name = model.Username,
                Surname = model.Surname,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Operator))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Operator));
            //if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Customer))
            //    await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Customer));

            if (await _roleManager.RoleExistsAsync(ApplicationRoles.Operator))
                await _userManager.AddToRoleAsync(user, ApplicationRoles.Operator);
            //if (await _roleManager.RoleExistsAsync(ApplicationRoles.Customer))
            //    await _userManager.AddToRoleAsync(user, ApplicationRoles.Customer);

            return Ok(new Response { Status = "Success", Message = "Operator created successfully!" });
        }
        //[Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPost]
        [Route("register-admin")]
        public async Task<IActionResult> RegisterAdmin([FromBody] RegisterModel model)
        {
            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User already exists!" });

            ApplicationUser user = new()
            {
                Name = model.Username,
                Surname = model.Surname,
                Email = model.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = model.Username
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "User creation failed! Please check user details and try again." });

            if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Admin))
                await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Admin));
            //if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Operator))
            //    await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Operator));
            //if (!await _roleManager.RoleExistsAsync(ApplicationRoles.Customer))
            //    await _roleManager.CreateAsync(new IdentityRole(ApplicationRoles.Customer));

            if (await _roleManager.RoleExistsAsync(ApplicationRoles.Admin))
                await _userManager.AddToRoleAsync(user, ApplicationRoles.Admin);
            //if (await _roleManager.RoleExistsAsync(ApplicationRoles.Operator))
            //    await _userManager.AddToRoleAsync(user, ApplicationRoles.Operator);
            //if (await _roleManager.RoleExistsAsync(ApplicationRoles.Customer))
            //    await _userManager.AddToRoleAsync(user, ApplicationRoles.Customer);

            return Ok(new Response { Status = "Success", Message = "Admin created successfully!" });
        }
        #endregion

        #region GET - (user info)
        [HttpGet,Route("GetUser/{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            ApplicationUser? user = await _userManager.FindByIdAsync(id);
            return user == null ? BadRequest() : Ok(_mapper.ToBasicModel(user));
        }

        [HttpGet, Route("GetAllUsers")]
        public async Task<IActionResult> GetAllAsync()
        {
            var users = _userManager.Users.ToList();
            List<UserBasicModel> usersModel = new();
            foreach (var user in users)
            {
                usersModel.Add(await ToBasicModel(user));
            }

            return Ok(usersModel);
        }

        [HttpPut, Route("Edit")]
        public async Task<IActionResult> Put(UserBasicModel model)
        {
            var entity = await _userManager.FindByIdAsync(model.Id);
            if(entity == null)
                return BadRequest("User not found");

            var role = await _roleManager.FindByNameAsync(model.Role);
            if(role == null)
                return BadRequest("Role not found");

            entity.Name = model.Name;
            entity.Surname = model.Surname;
            entity.UserName = model.Username;
            entity.Email = model.Email;

            var roles = await _userManager.GetRolesAsync(entity);
            await _userManager.RemoveFromRolesAsync(entity, roles);
            await _userManager.AddToRoleAsync(entity, model.Role);

            _unitOfWork.Commit();

            return Ok(_mapper.ToBasicModel(entity));
        }

        [HttpDelete, Route("Delete/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
                return BadRequest();

            entity.IsDeleted = true;
            _unitOfWork.Commit();

            return Ok(_mapper.ToBasicModel(entity));
        }

        [HttpDelete, Route("Restore/{id}")]
        public async Task<IActionResult> Restore(string id)
        {
            var entity = await _userManager.FindByIdAsync(id);
            if (entity == null)
                return BadRequest();

            entity.IsDeleted = false;
            _unitOfWork.Commit();

            return Ok(_mapper.ToBasicModel(entity));
        }
        #endregion



        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }

        private async Task<UserBasicModel> ToBasicModel(ApplicationUser entity) => new UserBasicModel
        {
            Id = entity.Id,
            Username = entity.UserName ?? "",
            Email = entity.Email ?? "",
            Name = entity.Name,
            Surname = entity.Surname,
            Role = (await _userManager.GetRolesAsync(entity))[0]
        };

    }
}
