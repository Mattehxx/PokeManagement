using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models.BasicModels
{
    public class ProductBasicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public bool IsDeleted { get; set; }
        public List<ProductIngredientBasicModel>? ProductIngredients { get; set; }
    }
}
