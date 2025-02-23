﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PokeManagement.Models;
using PokeManagementDAL.Auth;
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
            //var result = _managers.ProductManager.GetAll().ToList();
            return Ok(_managers.ProductManager.GetAll().Include(p => p.ProductType)?.Include(p=>p.ProductIngredients).ThenInclude(pi => pi.Ingredient).ToList().ConvertAll(_mapper.ToModel)); 
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
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpDelete,Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.ProductManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("product was not deleted");
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpPut,Route("Edit")]
        public IActionResult Put([FromBody]ProductModel model)
        {
            _managers.ProductManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("product was not modified");
        }
        #endregion

        #region ADDITIONAL
        //restore and delete (logical)
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpDelete,Route("LogicalDelete/{id}")]
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
        [Authorize(Roles =ApplicationRoles.Admin)]
        [HttpDelete,Route("LogicalRestore/{id}")]
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
        [HttpGet,Route("GetByCategoryId/{catId}")]
        public IActionResult GetByCat(int catId)
        {
            var prod = _managers.ProductManager.GetProdByCategory(catId);
            return prod == null ? BadRequest() : Ok(prod.ToList().ConvertAll(_mapper.ToModel));
        }
        #endregion

    }
}
