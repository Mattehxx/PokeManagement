using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
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
            return Ok(_managers.IngredientManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
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
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.IngredientManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not deleted");
        }
        [HttpPut, Route("Edit/{id}")]
        public IActionResult Put([FromBody] IngredientModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.IngredientManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not modified");
        }
    }
}
