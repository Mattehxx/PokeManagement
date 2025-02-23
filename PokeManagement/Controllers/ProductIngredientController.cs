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
            return Ok(_managers.ProductIngredientManager.GetAll().Include(pi=>pi.Ingredient).Include(pi=>pi.Product).ToList().ConvertAll(_mapper.ToModel));
        }
        [HttpGet, Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            var prod = _managers.ProductIngredientManager.GetById(id);
            return prod == null ? BadRequest("ingredient not found") : Ok(_mapper.ToModel(prod));
        }
        [HttpPost, Route("Add")]
        public IActionResult Post([FromBody] ProductIngredientModel model)
        {
            _managers.ProductIngredientManager.Create(_mapper.ToEntity(model));
            return _managers.Commit() ? Created() : BadRequest("ingredient was not created");
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.ProductIngredientManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not deleted");
        }
        [HttpPut, Route("Edit")]
        public IActionResult Put([FromBody] ProductIngredientModel model)
        {
            _managers.ProductIngredientManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("ingredient was not modified");
        }
    }
}
