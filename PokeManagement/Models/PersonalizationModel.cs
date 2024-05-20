using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class PersonalizationModel
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int IngredientId { get; set; }
        public bool IsDeleted { get; set; }
        public OrderDetailModel? OrderDetail { get; set; }
        public IngredientModel? Ingredient { get; set; }
    }
}