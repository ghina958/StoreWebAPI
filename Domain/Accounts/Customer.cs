using Domain.Enums;

namespace Domain.Accounts
{
    public class Customer : User
    {
        public string Address { get; set; }
        public override Role Role { get; set; } = Role.Customer;

        public ICollection<Order> Orders { get; set; }

    }
}
