using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public class Personalization
    {
        public int PersonalizationId { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductIngredientId { get; set; }
        public int Amount { get; set; }
        public OrderDetail? OrderDetail { get; set; }
        public ProductIngredient? ProductIngredient { get; set;}
    }
}
