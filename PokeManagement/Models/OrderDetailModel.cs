using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class OrderDetailModel
    {
        public int Id { get; set; }
        public int OrderdId { get; set; }
        public int ProductId { get; set; }
        public int Amount { get; set; }
        public double Price { get; set; }
        public OrderModel? Order { get; set; }
        public ProductModel? Product { get; set; }
        public List<PersonalizationModel>? Personalizations { get; set; }
    }
}
