using Domain.Enums;

namespace Domain.Accounts
{
    public class Admin : User
    {
        public DateTime DateHired { get; set; }
        public string AdminDepartment { get; set; }
        public override Role Role { get; set; } = Role.Admin;
    }
}
