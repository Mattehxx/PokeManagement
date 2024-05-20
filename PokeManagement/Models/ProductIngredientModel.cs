using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class ProductIngredientModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public ProductModel? Product { get; set; }
        public IngredientModel? Ingredient { get; set; }
    }
}