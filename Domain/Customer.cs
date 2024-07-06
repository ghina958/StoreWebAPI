

using Domain.Accounts;
using Domain.Enums;

namespace Domain
{
    public class Customer:User
    {
        public string Address { get; set; }
        public override Role Role { get; set; }= Role.Customer;
       
        public ICollection<Order> Orders { get; set; }

    }
}
