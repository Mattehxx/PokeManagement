using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductIngredientController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public ProductIngredientController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.ProductIngredientManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Ingredient/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.ProductIngredientManager.GetById(id);
            return prod == null ? BadRequest("ingredient not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Ingredient/Add")]
        public IActionResult Post([FromBody] ProductIngredientModel model)
        {
            _managers.ProductIngredientManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("ingredient was not created");
        }
        [HttpDelete, Route("Ingredient/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.ProductIngredientManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not deleted");
        }
        [HttpPut, Route("Ingredient/Edit/{id}")]
        public IActionResult Put([FromBody] ProductIngredientModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.ProductIngredientManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not modified");
        }
    }
}
