using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonalizationController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public PersonalizationController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.PersonalizationManager.GetAll().ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Personalization/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.PersonalizationManager.GetById(id);
            return prod == null ? BadRequest("personalization not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Personalization/Add")]
        public IActionResult Post([FromBody] PersonalizationModel model)
        {
            _managers.PersonalizationManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("personalization was not created");
        }
        [HttpDelete, Route("Personalization/Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.PersonalizationManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("personalization was not deleted");
        }
        [HttpPut, Route("Personalization/Edit/{id}")]
        public IActionResult Put([FromBody] PersonalizationModel model, int id)
        {
            if (model.Id != id)
                model.Id = id;
            _managers.PersonalizationManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("personalization was not modified");
        }

    }
}
