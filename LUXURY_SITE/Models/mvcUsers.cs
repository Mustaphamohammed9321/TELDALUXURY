using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace LUXURY_SITE.Models
{
    public class mvcUsers
    {
        public string SigninErrorMessage { get; set; }

        public int Id { get; set; }

        [Required(ErrorMessage = "This field is required")]
        [StringLength(50), MinLength(3), MaxLength(50)]
        //[RegularExpression]
        public string FirstName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(50), MinLength(3), MaxLength(50)]
        //[RegularExpression]
        public string LastName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [StringLength(50), MinLength(3), MaxLength(50)]
        //[RegularExpression]
        public string OtherName { get; set; }

        //public int StatusId { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string Country { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string State { get; set; }


        [Required(ErrorMessage = "This field is required")]
        public string LGA { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }



        //[Column(TypeName = "smalldatetime")]

        [StringLength(11, ErrorMessage = "A valid phone number should contain 11-digits at least"), MaxLength(11)]
        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.PhoneNumber)]
        //[RegularExpression]
        public string PhoneNumber { get; set; }


        //[Required(ErrorMessage = "This field is required")]
        //[DataType(DataType.Text)]
        //[MinLength(11), MaxLength(20)]
        ////[RegularExpression()]
        //public string UserName { get; set; }


        [Required(ErrorMessage = "This field is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "This is a required field")]
        [Compare("Password")]
        public string ConfirmPassword { get; set; }


        public Nullable<System.DateTime> DateAdded { get; set; } //automatic field


        [DataType(DataType.ImageUrl)]
        public string Photo { get; set; }  //not compulsory field


        [DataType(DataType.MultilineText)]
        [MinLength(20), MaxLength(100)]
        public string ResidentialAddress { get; set; }  //not compulsory field
    }
}