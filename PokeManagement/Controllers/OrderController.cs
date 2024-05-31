using Microsoft.AspNetCore.Authorization;
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
            return Ok(_managers.OrderManager.GetAll().Include(o=>o.Details).Include(o=>o.OrderType).ToList().ConvertAll(_mapper.ToModel));
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
        [Authorize(Roles = $"{ApplicationRoles.Admin},{ApplicationRoles.Operator}")]
        //[Authorize(Roles = ApplicationRoles.Operator)]
        [HttpDelete, Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            _managers.OrderManager.DeleteById(id);
            return _managers.Commit() ? Ok() : BadRequest("Order was not deleted");
        }
        [HttpPut, Route("Edit")]
        public IActionResult Put([FromBody] OrderModel model)
        {
            //if (_managers.OrderManager.GetById(model.Id) == null)
            //    return BadRequest("Order not found");
            _managers.OrderManager.Update(_mapper.ToEntity(model));
            return _managers.Commit() ? Ok() : BadRequest("Order was not modified");
        }
        [Authorize(Roles =ApplicationRoles.Admin)]
        [HttpPost,Route("SaveOrderHistory")]
        public IActionResult StoreProcedureHistory([FromBody] OrderHistoryModel model)
        {
            return _managers.OrderManager.ExecuteStoreProcedure(model.StartDate, model.EndDate) ? Ok() : BadRequest();
        }
        [Authorize(Roles = ApplicationRoles.Operator)]
        [HttpPost,Route("AddOrderDriveThrough")]
        public IActionResult AddOrderDriveThrough(OrderModel orderModel)
        {
            try
            {
                var toAdd = _mapper.ToEntity(orderModel);
                _managers.OrderManager.AddOrderDriveThrough(toAdd);
                return _managers.Commit() ? Ok() : BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles = ApplicationRoles.Operator)]
        [HttpGet,Route("GetOrderToExec")]
        public IActionResult GetOrderToExec()
        {
            return Ok(_managers.OrderManager.GetOrdersToExec().ToList().ConvertAll(_mapper.ToBasicModel));
        }
        [Authorize(Roles = ApplicationRoles.Operator)]
        [HttpPut, Route("ExecOrder/{id}")]
        public IActionResult ExecOrder(int id)
        {
            try
            {
                if (!_managers.OrderManager.ExecOrder(id))
                {
                    return BadRequest("order not found");
                }
                return _managers.Commit() ? Ok() : BadRequest();
            }catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        #region ADMIN
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpDelete, Route("LogicalDelete/{id}")]
        public IActionResult LogicalDelete(int id)
        {
            _managers.OrderManager.LogicalDelete(id, true);
            return _managers.Commit() ? Ok() : BadRequest("cannot delete");
        }
        [Authorize(Roles = ApplicationRoles.Admin)]
        [HttpDelete, Route("LogicalRestore/{id}")]
        public IActionResult LogicalRestore(int id)
        {
            _managers.OrderManager.LogicalDelete(id, false);
            return _managers.Commit() ? Ok() : BadRequest("cannot restore");
        }
        #endregion

        #region CUSTOMER-ANONYMOUS (order inloco e takeAway)
        [Authorize(Roles =ApplicationRoles.Customer)]
        [Authorize(Roles =ApplicationRoles.Anonymous)]
        [HttpPost,Route("AddInLocalOrder")]
        public IActionResult AddInLocalOrder(OrderModel orderModel)
        {
            try
            {
                var toAdd = _mapper.ToEntity(orderModel);
                _managers.OrderManager.AddOrderInLocal(toAdd);
                return _managers.Commit() ? Ok() : BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [Authorize(Roles =ApplicationRoles.Customer)]
        [Authorize(Roles =ApplicationRoles.Anonymous)]
        [HttpPost,Route("AddTakeAwayOrder")]
        public IActionResult AddTakeAwayOrder(OrderModel orderModel)
        {
            try
            {
                var toAdd = _mapper.ToEntity(orderModel);
                _managers.OrderManager.AddOrderTakeAway(toAdd);
                return _managers.Commit() ? Ok() : BadRequest();
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        #endregion

    }
}
