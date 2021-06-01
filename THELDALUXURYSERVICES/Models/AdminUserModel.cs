using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE.Models
{
    public class AdminUserModel
    {
        public int AdminId { get; set; }

        [Required(ErrorMessage="This field is required")]
        public string FirstName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string LastName { get; set; }
        
        public string OtherName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string UserName { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; init; }

        public string  Photo { get; set; }
        
        [Required(ErrorMessage = "This field is required")]
        public string RoleId { get; set; }

        [DataType(DataType.MultilineText)]
        public string ResidentialAddress { get; set; }
    }
}
