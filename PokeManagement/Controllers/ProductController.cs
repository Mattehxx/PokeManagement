using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
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
        #region BASIC CRUD
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_managers.ProductManager.GetAll().Include(p=>p.ProductType)?.Include(p=>p.ProductIngredients).ThenInclude(pi=>pi.Ingredient).ToList().ConvertAll(_mapper.ToModel)); 
        }
        [HttpGet,Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.ProductManager.GetById(id);
            return prod == null ? BadRequest("product not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost,Route("Add")]
        public IActionResult Post([FromBody] ProductModel model)
        {
            _managers.ProductManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("product was not created");
        }
        [HttpDelete,Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.ProductManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("product was not deleted");
        }
        [HttpPut,Route("Edit/{id}")]
        public IActionResult Put([FromBody]ProductModel model,int id)
        {
            if(model.Id != id)
                model.Id = id;
            _managers.ProductManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("product was not modified");
        }
        #endregion

        #region ADDITIONAL
        //restore and delete (logical)
        [HttpPut,Route("LogicalDelete/{id}")]
        public IActionResult LogicalDelete(int id)
        {
            try
            {
                _managers.ProductManager.LogicalDelete(id,true);
                return _managers.Commit() ? Ok() : BadRequest();
            }catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        [HttpPut,Route("LogicalRestore/{id}")]
        public IActionResult LogicalRestore(int id)
        {
            try
            {
                _managers.ProductManager.LogicalDelete(id, false);
                return _managers.Commit() ? Ok() : BadRequest();
            }catch(Exception ex)
            {
                return Problem(ex.Message);
            }
        }
        //Add and remove ingredients
        //[HttpPost,Route("Product/AddIngredient/{id}")]
        //public IActionResult AddIngredient(int id)
        //{
        //    try
        //    {
        //        _managers.ProductManager
        //    }catch(Exception ex)
        //    {
        //        return Problem(ex.Message);
        //    }
        //}
        
        #endregion

    }
}
