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
        public bool LogicalDelete(int id);
        public bool AddProducts(List<Product> toAddProducts);
        public bool RemoveProducts(List<Product> toRemoveProducts);
        public bool AddProduct(Product product);
        public bool RemoveProduct(int id);
        //opzionale
        public void ToImplement(); // definizione ingredienti default e ingredienti per possibile personalizzazione
    }
}
