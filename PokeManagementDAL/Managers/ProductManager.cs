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
        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void AddProducts(List<Product> toAddProducts)
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product> GetListDetails()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Product>? GetProdByCategory(int categoryId)
        {
            return Filter(p=>p.ProductTypeId == categoryId);
        }

        public void LogicalDelete(int id,bool confirm)
        {
            Filter(p=>p.ProductId == id).FirstOrDefault()!.IsDeleted = confirm;
        }

        public void RemoveProduct(int id)
        {
            throw new NotImplementedException();
        }

        public void RemoveProducts(List<Product> toRemoveProducts)
        {
            throw new NotImplementedException();
        }

        public void ToImplement()
        {
            throw new NotImplementedException();
        }
    }
}
