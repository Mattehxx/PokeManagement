using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models.BasicModels
{
    public class IngredientBasicModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double AdditionalCost { get; set; }
        public string Description { get; set; }
        public bool Allergen { get; set; }
        public double Calories { get; set; }
        public bool IsDeleted { get; set; }
    }
}
