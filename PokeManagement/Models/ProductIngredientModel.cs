using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class ProductIngredientModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public int MaxAllowed { get; set; }
        public bool IsIncluded { get; set; }
        public ProductBasicModel? Product { get; set; }
        public IngredientBasicModel? Ingredient { get; set; }
        public List<PersonalizationBasicModel>? Personalizations { get; set; }
    }
}