using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TELDALUXURY.Models
{
    public class Staff
    {
        public int Id { get; set; }
        public string StaffId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Age { get; set; }
        public DateTime DateOfBirth { get; set; }
        public DateTime DateCreated { get; set; }
        public string ResidentAddress { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool isUpdate { get; set; }
        public bool isDeleted { get; set; }
    }                               
}
