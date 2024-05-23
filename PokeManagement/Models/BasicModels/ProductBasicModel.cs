using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models.BasicModels
{
    public class ProductBasicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        //solo per il modello (default personalization) -> senza gli ingredienti presenti nel prodotto
        //public List<SpecificPersonalization>? specificPersonalizations { get; set; }
    }
}
