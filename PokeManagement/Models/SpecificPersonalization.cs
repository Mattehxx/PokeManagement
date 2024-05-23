namespace PokeManagement.Models
{
    public class SpecificPersonalization
    {
        //modello per escludere i prodotti custom già presenti nel prodotto base
        public int DefaultPersonalizationId { get; set; }
        public int ProductId { get; set; }
        public int IngredientId { get; set; }
        public int Amount { get; set; }
        public int MaxAllowed {  get; set; }
    }
}