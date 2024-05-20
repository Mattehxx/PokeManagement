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
        public int OderTypeId { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
    }
}
