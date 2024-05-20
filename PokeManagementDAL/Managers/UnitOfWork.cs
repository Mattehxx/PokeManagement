using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    internal class UnitOfWork : IUnitOfWork
    {
        public readonly PokeDbContext _ctx;
        public IProductIngredientManager ProductIngredientManager { get; private set; }
        public IProductManager ProductManager { get; private set; }
        public IProductTypeManager ProductTypeManager { get; private set; }
        public IPersonalizationManager PersonalizationManager { get; private set; }
        public IOrderDetailManager OrderDetailManager { get; private set; }
        public IOrderTypeManager OrderTypeManager { get; private set; }
        public IOrderManager OrderManager { get; private set; }
        public IIngredientManager IngredientManager { get; private set; }
        public IIngredientTypeManager IngredientTypeManager { get; private set; }
        public UnitOfWork(PokeDbContext ctx)
        {
            _ctx = ctx;
            ProductManager = new ProductManager(ctx);
            ProductIngredientManager = new ProductIngredientManager(ctx);
            ProductTypeManager = new ProductTypeManager(ctx);
            PersonalizationManager = new PersonalizationManager(ctx);
            OrderDetailManager = new OrderDetailManager(ctx);
            OrderTypeManager = new OrderTypeManager(ctx);
            OrderManager = new OrderManager(ctx);
            IngredientManager = new IngredientManager(ctx);
            IngredientTypeManager = new IngredientTypeManager(ctx);
        }

        public bool Commit()
        {
            return _ctx.SaveChanges() > 0;
        }
    }
}
