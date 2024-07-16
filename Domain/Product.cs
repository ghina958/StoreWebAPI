using Domain.Abstract;

namespace Domain
{
    public class Product : BaseEntity<int>
    {
        public string Name { get; set; }
        public File? Image { get; set; }
        public int? ImageID { get; set; }
        public int Price { get; set; }
        public int StoreId { get; set; }
        public TheStore.Store Store { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
