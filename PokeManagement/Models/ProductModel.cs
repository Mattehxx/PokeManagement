
using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public double Price { get; set; }
        public int ProductTypeId { get; set; }
        public ProductTypeModel? ProductType { get; set; }
        public List<OrderDetailModel>? OrderDetails { get; set; }
        public List<ProductIngredientModel>? ProductIngredients { get; set; }
    }
}
