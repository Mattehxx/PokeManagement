using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public class OrderDetail
    {
        public int OrderDetailId { get; set; }
        public int OderdId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }

        public Order Order { get; set; }
    }
}
