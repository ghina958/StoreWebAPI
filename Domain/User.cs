using Domain.Abstract;
using Domain.Enums;

namespace Domain;

    public abstract class User : BaseEntity<int>
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
       
        public string Email { get; set; }
        public string phone { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
        public abstract Role Role { get; set; }
        
    }
    

