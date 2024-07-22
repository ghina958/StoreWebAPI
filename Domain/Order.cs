using Domain.Abstract;
using Domain.Accounts;
using Domain.Enums;

namespace Domain
{
    public class Order : BaseEntity<int>
    {
        public int No { get; set; }
        public DateTime Date { get; set; }
        public OrderStatus OrderStatus { get; set; }
        public int CustomerId { get; set; }
        public Customer Customer { get; set; }
        public ICollection<OrderItem> OrderItems { get; set; }
    }
}
