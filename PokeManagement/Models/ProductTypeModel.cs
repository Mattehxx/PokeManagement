using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models
{
    public class ProductTypeModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Description { get; set; }
        public List<ProductBasicModel>? Products { get; set; }
    }
}
