namespace PokeManagement.Models.BasicModels
{
    public class PersonalizationBasicModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int ProductIngredientId { get; set; }
        public ProductIngredientBasicModel? ProductIngredient { get; set; }
    }
}
