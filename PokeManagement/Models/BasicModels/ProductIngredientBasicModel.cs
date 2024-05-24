namespace PokeManagement.Models.BasicModels
{
    public class ProductIngredientBasicModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public string IngredientName { get; set; }
        public double IngredientPrice { get; set; }
        public int Amount { get; set; }
        public int MaxAllowed { get; set; }
        public bool IsIncluded { get; set; }
    }
}
