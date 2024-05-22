using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    public interface IProductManager : IManager<Product>
    {
        //RUOLO ADMIN
        public IQueryable<Product> GetListDetails(); //lista ingredienti con dettaglio
        public void LogicalDelete(int id,bool confirm);
        public void AddProducts(List<Product> toAddProducts);
        public void RemoveProducts(List<Product> toRemoveProducts);
        public void AddProduct(Product product);
        public void RemoveProduct(int id);
        //opzionale
        public void ToImplement(); // definizione ingredienti default e ingredienti per possibile personalizzazione
        //aggiunta
        public IQueryable<Product>? GetProdByCategory(int categoryId);
    }
}
