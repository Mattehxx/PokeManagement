using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public class OrderType
    {
        public int OrderTypeId { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public List<Order>? Orders { get; set;}
    }
}
