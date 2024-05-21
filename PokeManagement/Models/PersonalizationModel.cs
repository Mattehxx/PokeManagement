using PokeManagementDAL.Data;

namespace PokeManagement.Models
{
    public class PersonalizationModel
    {
        public int Id { get; set; }
        public int OrderDetailId { get; set; }
        public int DefaultPersonalizationId { get; set; }
        public bool IsDeleted { get; set; }
        public OrderDetailModel? OrderDetail { get; set; }
        public DefaultPersonalizationModel? DefaultPersonalization { get; set; }
    }
}