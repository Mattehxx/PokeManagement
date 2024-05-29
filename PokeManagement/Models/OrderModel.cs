using PokeManagementDAL.Auth;
using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using PokeManagement.Models.BasicModels;

namespace PokeManagement.Models
{
    public class OrderModel
    {
        public int Id { get; set; }
        [MaxLength(3)]
        public string? ReservationCode { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ExecDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
        public int OrderTypeId { get; set; }
        [MaxLength(450)]
        public string? MandatorId { get; set; }
        [MaxLength(450)]
        public string? OperatorId { get; set; }
        public OrderTypeBasicModel? OrderType { get; set; }
        public ApplicationUserModel? Mandator { get; set; }
        public ApplicationUserModel? Operator { get; set; }
        public List<OrderDetailBasicModel> Details { get; set; }
    }
}