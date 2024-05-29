using PokeManagement.Models.BasicModels;
using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public OrderBasicModel? Order { get; set; }
        public ProductBasicModel? Product { get; set; }
        public List<PersonalizationBasicModel>? Personalizations { get; set; }
    }
}
