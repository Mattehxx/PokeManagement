using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class DefaultPersonalizationModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int MaxAllowed { get; set; }
        public ProductModel? Product { get; set; }
        public IngredientModel? Ingredient { get; set; }
        public List<PersonalizationModel>? Personalizations { get; set; }
    }
}