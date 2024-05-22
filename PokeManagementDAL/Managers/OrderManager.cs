using Microsoft.EntityFrameworkCore;
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

        public bool ExecuteStoreProcedure(DateTime start,DateTime end)
        {
            var command = $"EXECUTE [dbo].[MoveToHistoryTables] {start},{end}";
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
    }
}
