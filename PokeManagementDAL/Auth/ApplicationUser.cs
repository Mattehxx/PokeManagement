using Microsoft.AspNetCore.Identity;
using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PokeManagementDAL.Auth
{
    public class ApplicationUser : IdentityUser
    {
        [MaxLength(100)]
        public string Name { get; set; }
        [MaxLength(100)]
        public string Surname { get; set; }
        public bool IsDeleted { get; set; }
        [InverseProperty(nameof(Order.Mandator))]
        public List<Order>? MandatorOrders { get; set; }
        [InverseProperty(nameof(Order.Operator))]
        public List<Order>? OperatorOrders { get; set; }
    }
}
