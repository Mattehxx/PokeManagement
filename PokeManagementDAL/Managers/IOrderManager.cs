using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public interface IOrderManager : IManager<Order>
    {
        //ADMIN
        #region ADMIN
        public bool ExecuteStoreProcedure(); // aggiornare storico ordini
        #endregion
        //OPERATORE
        #region OPERATORE
        public bool AddOrderDriveThrough();
        public IQueryable<Order> GetOrdersToExec(); //ordinati per drive/asporto/in loco
        public bool ExecOrder(int id); //evadere un ordine
        public bool ExecMultipleOrders(List<Order> orders); //oppure list<int> ids
        //opzionale
        public bool PersonalizeOrderProd(Order order);
        #endregion
        #region CUSTOMER/ANONYMOUS
        //public bool AddOrder   --> take away e in loco
        //opzionale:
        public bool PersonalizeOrderProduct(int orderId,Product product);
        #endregion
    }
}
