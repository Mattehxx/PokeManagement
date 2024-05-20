using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PokeManagement.Models;
using PokeManagementDAL.Managers;

namespace PokeManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        public readonly IUnitOfWork _managers;
        public readonly Mapper _mapper;
        public ProductController(IUnitOfWork managers, Mapper mapper)
        {
            _managers = managers;
            _mapper = mapper;
        }
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.ProductManager.GetAll().ToList().ConvertAll(_mapper.ToModel)); 
        }
        [HttpGet,Route("Product/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.ProductManager.GetById(id);
            return prod == null ? BadRequest("product not found") : Ok(_mapper.ToModel(prod));
        }
    }
}
