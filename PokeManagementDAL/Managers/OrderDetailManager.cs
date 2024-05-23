using PokeManagementDAL.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Managers
{
    internal class OrderDetailManager(PokeDbContext ctx) : GenericManager<OrderDetail>(ctx),IOrderDetailManager
    {
    }
}
