using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models
{
    public class ApplicationUserModel
    {
        public string Id { get; set; }
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public string Email { get; set; }
        public List<OrderModel>? MandatorOrders { get; set; }
        public List<OrderModel>? OperatorOrders { get; set; }
    }
}