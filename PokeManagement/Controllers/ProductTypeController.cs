using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductTypeController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public ProductTypeController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.ProductTypeManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prodType = _managers.ProductTypeManager.GetById(id);
            return prodType == null ? BadRequest("product type not found") : Ok(_mapper.ToModel(prodType));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] ProductTypeModel model)
        {
            _managers.ProductTypeManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("product type was not created");
        }
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.ProductTypeManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("product type was not deleted");
        }
        [HttpPut, Route("Edit/{id}")]
        public IActionResult Put([FromBody] ProductTypeModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.ProductTypeManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("product type was not modified");
        }
    }
}
