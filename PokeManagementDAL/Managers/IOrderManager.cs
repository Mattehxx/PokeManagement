﻿using PokeManagementDAL.Data;
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
        public void AddOrderDriveThrough();
        public IQueryable<Order> GetOrdersToExec(); //ordinati per drive/asporto/in loco
        public void ExecOrder(int id); //evadere un ordine
        public void ExecMultipleOrders(List<Order> orders); //oppure list<int> ids
        //opzionale
        public void PersonalizeOrderProd(Order order);
        #endregion
        #region CUSTOMER/ANONYMOUS
        //public bool AddOrder   --> take away e in loco
        //opzionale:
        public void PersonalizeOrderProduct(int orderId,Product product);
        #endregion
    }
}
