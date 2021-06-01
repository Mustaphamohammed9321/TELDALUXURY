using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class mvcAdminUser
    {
        public int AdminId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        public string EmailAddress { get; set; }
        public string PhoneNumber { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Photo { get; set; }
        public Nullable<int> RoleId { get; set; }
        public string ResidentialAddress { get; set; }
    }
}
