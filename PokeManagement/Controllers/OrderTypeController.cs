using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Data;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderTypeController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public OrderTypeController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.OrderTypeManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.OrderTypeManager.GetById(id);
            return prod == null ? BadRequest(" not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] OrderTypeModel model)
        {
            _managers.OrderTypeManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("order type was not created");
        }
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.OrderTypeManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("order type was not deleted");
        }
        [HttpPut, Route("Edit/{id}")]
        public IActionResult Put([FromBody] OrderTypeModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.OrderTypeManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("order type was not modified");
        }
    }
}
