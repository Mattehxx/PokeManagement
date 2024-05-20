using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PokeManagementDAL.Data
{
    public class Product
    {
        public int ProductId { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public int ProductTypeId { get; set; }
        public ProductType? ProductType { get; set; }
    }
}
