﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAPPER_WEBAPI_TELDA.Models
{
    public class CreateUserLogin
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName { get; set; }
        //public string StatusId { get; set; }  // autogenerated from stored procedure
        //public string DateAdded { get; set; }   // autogenerated from stored procedure 
        public string PhoneNumber { get; set; }
        //public string UserName { get; set; }
        public string EmailAddress { get; set; }
        public string Password { get; set; }
        //public string PasswordHash { get; set; }
    }
}
