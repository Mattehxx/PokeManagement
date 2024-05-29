namespace PokeManagement.Models.BasicModels
{
    public class OrderDetailBasicModel
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public ProductBasicModel? Product { get; set; }
        public List<PersonalizationBasicModel>? Personalizations { get; set; }
    }
}
