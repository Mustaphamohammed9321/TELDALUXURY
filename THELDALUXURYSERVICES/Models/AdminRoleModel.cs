using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class AdminRoleModel
    {
        public int RoleId { get; set; }
        public string Role { get; set; }
        public Nullable<int> AdminId { get; set; }
    }
}
