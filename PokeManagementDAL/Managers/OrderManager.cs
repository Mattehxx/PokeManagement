﻿using Microsoft.EntityFrameworkCore;
using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class OrderManager(PokeDbContext ctx) : GenericManager<Order>(ctx), IOrderManager
    {
        public void AddOrderDriveThrough(Order order)
        {
            order.OrderTypeId = 1;
            Create(order);
        }

        public void AddOrderInLocal(Order order)
        {
            order.OrderTypeId = 3;
            Create(order);
        }

        public void AddOrderTakeAway(Order order)
        {
            order.OrderTypeId = 2;
            Create(order);
        }

        public void ExecMultipleOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }

        public bool ExecOrder(int id)
        {
            var o = _dbSet.SingleOrDefault(o=>o.OrderId == id);
            if (o == null)
                return false;
            o.ExecDate = DateTime.Now;
            o.IsCompleted = true;
            return true;
        }

        public bool ExecuteStoreProcedure(DateTime start, DateTime end)
        {
            var command = $"EXECUTE [dbo].[MoveToHistoryTables] '{start.ToString("s")}', '{end.ToString("s")}'";
            return _ctx.Database.ExecuteSqlRaw(command) > 0;
        }

        public IQueryable<Order> GetOrdersToExec()
        {
            return _dbSet.Where(o => o.ExecDate == null || !o.IsCompleted);
        }

        public void PersonalizeOrderProd(Order order)
        {
            throw new NotImplementedException();
        }

        public void PersonalizeOrderProduct(int orderId, Product product)
        {
            throw new NotImplementedException();
        }
        public override Order? GetById(int id)
        {
            return _dbSet.Include(o=>o.OrderType).Include(o => o.Details).ThenInclude(dt => dt.Product).ThenInclude(p => p.ProductIngredients).ThenInclude(pi => pi.Ingredient)
                .Include(o => o.Details).ThenInclude(dt => dt.Personalizations).ThenInclude(p => p.ProductIngredient).ThenInclude(pi => pi.Ingredient)
                .SingleOrDefault(o=>o.OrderId == id);
        }
        public void LogicalDelete(int ingredientId,bool confirm)
        {
            var order = GetById(ingredientId);
            if (order != null)
                order.IsDeleted = confirm;
        }
    }
}
