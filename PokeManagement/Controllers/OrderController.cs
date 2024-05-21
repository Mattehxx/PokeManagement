using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public OrderController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.OrderManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.OrderManager.GetById(id);
            return prod == null ? BadRequest("Order not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] OrderModel model)
        {
            _managers.OrderManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("Order was not created");
        }
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.OrderManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("Order was not deleted");
        }
        [HttpPut, Route("Edit/{id}")]
        public IActionResult Put([FromBody] OrderModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.OrderManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("Order was not modified");
        }

    }
}
