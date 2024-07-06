using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Accounts
{
    public class Admin : User
    {
        public DateTime DateHired { get; set; }
        public string AdminDepartment { get; set; }
        public override Role Role { get; set; } = Role.Admin;
    }
}
