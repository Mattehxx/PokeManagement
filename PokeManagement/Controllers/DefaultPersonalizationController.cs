using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DefaultPersonalizationController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public DefaultPersonalizationController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.DefaultPersonalizationManager.GetAll().ToList());
        }
        [HttpGet,Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var dp = _managers.DefaultPersonalizationManager.GetById(id);
            if (dp == null)
                return BadRequest();
            return Ok(dp);
        }
        [HttpPost,Route("Add")]
        public IActionResult Post([FromBody] DefaultPersonalizationModel model)
        {
            _managers.DefaultPersonalizationManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest();
        }

    }
}
