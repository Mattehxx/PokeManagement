using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
            return Filter(p => p.ProductTypeId == categoryId)
                ?.Include(p => p.ProductIngredients)?.ThenInclude(pi => pi.Ingredient);
        }

        public void LogicalDelete(int ingredientId,bool confirm)
        {
            var ing = GetById(ingredientId);
            if (ing != null)
                ing.IsDeleted = confirm;
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
        public override Product? GetById(int id)
        {
            return  _dbSet.Include(p=>p.ProductIngredients).ThenInclude(pi=>pi.Ingredient).SingleOrDefault(p=>p.ProductId == id);
        }
    }
}
