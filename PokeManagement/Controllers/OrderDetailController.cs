using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public OrderDetailController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.OrderDetailManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.OrderDetailManager.GetById(id);
            return prod == null ? BadRequest("order detail not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] OrderDetailModel model)
        {
            _managers.OrderDetailManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("order detail was not created");
        }
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.OrderDetailManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("order detail was not deleted");
        }
        [HttpPut, Route("Edit/{id}")]
        public IActionResult Put([FromBody] OrderDetailModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.OrderDetailManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("order detail was not modified");
        }
    }
}
