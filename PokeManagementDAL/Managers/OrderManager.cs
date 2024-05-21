using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class OrderManager(PokeDbContext ctx) : GenericManager<Order>(ctx), IOrderManager
    {
        public void AddOrderDriveThrough()
        {
            throw new NotImplementedException();
        }

        public void ExecMultipleOrders(List<Order> orders)
        {
            throw new NotImplementedException();
        }

        public void ExecOrder(int id)
        {
            throw new NotImplementedException();
        }

        public bool ExecuteStoreProcedure()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Order> GetOrdersToExec()
        {
            throw new NotImplementedException();
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
