using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public class Order
    {
        public int OrderId { get; set; }
        [MaxLength(3)]
        public string ReservationCode { get; set; }
        public DateTime? InsertDate { get; set; }
        public bool IsCompleted { get; set; }
        public bool IsDeleted {  get; set; }
        public int TypeId { get; set; }
        [MaxLength(450)]
        public string MandatorId { get; set; }
        [MaxLength(450)]
        public string OperatorId { get; set; }

    }
}
