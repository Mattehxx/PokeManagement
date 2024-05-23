using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Auth;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration) : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager = userManager;
        private readonly RoleManager<IdentityRole> _roleManager = roleManager;
        private readonly IConfiguration _configuration = configuration;
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
            return user == null ? BadRequest() : Ok(new UserBasicModel
            {
                Name = user.Name,
                Surname = user.Surname,
                Username = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty
            });
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
        
    }
}
