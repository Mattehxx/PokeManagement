namespace PokeManagementDAL.Data
{
    public class DefaultPersonalization
    {
        public int DefaultPersonalizationId { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int MaxAllowed {  get; set; }
        public Product? Product { get; set; }
        public Ingredient? Ingredient { get; set;}
        public List<Personalization>? Personalizations { get; set; }
    }
}