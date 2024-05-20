using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public class ProductManager(PokeDbContext ctx) : GenericManager<Product>(ctx), IProductManager
    {
        public bool AddIngredients()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetListDetails()
        {
            throw new NotImplementedException();
        }

        public bool LogicalDelete()
        {
            throw new NotImplementedException();
        }

        public bool RemoveIngredients()
        {
            throw new NotImplementedException();
        }

        public void ToImplement()
        {
            throw new NotImplementedException();
        }
    }
}
