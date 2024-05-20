using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models
{
    public class ApplicationUserModel
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public List<OrderModel>? MandatorOrders { get; set; }
        public List<OrderModel>? OperatorOrders { get; set; }
    }
}