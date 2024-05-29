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
    public class IngredientController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public IngredientController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.IngredientManager.GetAll().Include(im=>im.IngredientType).ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.IngredientManager.GetById(id);
            return prod == null ? BadRequest("ingredient not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] IngredientModel model)
        {
            _managers.IngredientManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("ingredient was not created");
        }
        [Authorize(Roles =ApplicationRoles.Admin)]
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.IngredientManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not deleted");
        }
        [HttpPut, Route("Edit")]
        public IActionResult Put([FromBody] IngredientModel model)
        {
            _managers.IngredientManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not modified");
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPut,Route("LogicalDelete/{id}")]
        public IActionResult LogicalDelete(int id)
        {
            _managers.IngredientManager.LogicalDelete(id,true);
            return _managers.Commit() ? Ok() : BadRequest("cannot delete");
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPut, Route("LogicalRestore/{id}")]
        public IActionResult LogicalRestore(int id)
        {
            _managers.IngredientManager.LogicalDelete(id, false);
            return _managers.Commit() ? Ok() : BadRequest("cannot restore");
        }
    }
}
