namespace PokeManagement.Models.BasicModels
{
    public class ProductIngredientBasicModel
    {
        public int Id { get; set; }
        public int Amount { get; set; }
        public int MaxAllowed { get; set; }
        public bool IsIncluded { get; set; }
    }
}
