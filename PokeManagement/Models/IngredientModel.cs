using PokeManagementDAL.Data;
using System.ComponentModel.DataAnnotations;

namespace PokeManagement.Models
{
    public class IngredientModel
    {
        public int Id { get; set; }
        [MaxLength(50)]
        public string Name { get; set; }
        public double AddictionalCost { get; set; }
        [MaxLength(200)]
        public string Description { get; set; }
        public bool Allegergen { get; set; }
        public double Calories { get; set; }
        public bool IsDeleted { get; set; }
        public int IngredientTypeId { get; set; }
        public IngredientTypeModel? IngredientType { get; set; }
        public List<ProductIngredientModel>? ProductIngredients { get; set; }
    }
}