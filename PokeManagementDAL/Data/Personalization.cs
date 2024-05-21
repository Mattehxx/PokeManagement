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
        public int DefaultPersonalizationId { get; set; }
        public bool IsDeleted { get; set; }
        public OrderDetail? OrderDetail { get; set; }
        public DefaultPersonalization? DefaultPersonalization { get; set; }
    }
}
