using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class PersonalizationModel
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductIngredientId { get; set; }
        public bool IsRemoved { get; set; }
        public OrderDetailBasicModel? OrderDetail { get; set; }
        public ProductIngredientBasicModel? ProductIngredient { get; set; }
    }
}