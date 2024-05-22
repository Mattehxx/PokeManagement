using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public class ProductIngredient
    {
        public int ProductIngredientId { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public int MaxAllowed { get; set; }
        public bool IsIncluded { get; set; }
        public Product? Product { get; set; }
        public Ingredient? Ingredient { get; set; }
        public List<Personalization>? Personalizations { get; set; }
    }
}
