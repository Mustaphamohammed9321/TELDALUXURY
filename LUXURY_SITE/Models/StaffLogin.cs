using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LUXURY_SITE.Models
{
    public class StaffLogin
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordHash { get; set; }
        public bool isUpdated { get; set; }
        public bool PasswordChanged { get; set; }
        public bool isDeleted { get; set; }
    }
}
