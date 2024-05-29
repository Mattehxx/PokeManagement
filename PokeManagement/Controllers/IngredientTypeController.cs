using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeManagement.Models;
using PokeManagementDAL.Auth;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientTypeController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public IngredientTypeController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.IngredientTypeManager.GetAll().Include(it=>it.Ingredients).ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.IngredientTypeManager.GetById(id);
            return prod == null ? BadRequest("ingredient type not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] IngredientTypeModel model)
        {
            _managers.IngredientTypeManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("ingredient type was not created");
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.IngredientTypeManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("ingredient type was not deleted");
        }
        [HttpPut, Route("Edit")]
        public IActionResult Put([FromBody] IngredientTypeModel model)
        {
            _managers.IngredientTypeManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("ingredient type was not modified");
        }
    }
}
