using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class PersonalizationModel
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int ProductIngredientId { get; set; }
        public bool IsRemoved { get; set; }
        public OrderDetailModel? OrderDetail { get; set; }
        public ProductIngredientModel? ProductIngredient { get; set; }
    }
}