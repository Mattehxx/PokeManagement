using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public interface IUnitOfWork
    {
        public IProductIngredientManager ProductIngredientManager { get; }
        public IProductManager ProductManager { get; }
        public IProductTypeManager ProductTypeManager {get;} 
        public IPersonalizationManager PersonalizationManager { get; }
        public IOrderDetailManager OrderDetailManager { get; }
        public IOrderTypeManager OrderTypeManager { get; }
        public IOrderManager OrderManager { get; }
        public IIngredientManager IngredientManager { get; }
        public IIngredientTypeManager IngredientTypeManager { get; }
        public bool Commit(); //savechanges
    }
}
