using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models.BasicModels
{
    public class OrderBasicModel
    {
        public int Id { get; set; }
        public string ReservationCode { get; set; }
        public DateTime? InsertDate { get; set; }
        public DateTime? ExecDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted { get; set; }
    }
}
