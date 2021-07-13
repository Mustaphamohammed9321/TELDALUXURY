using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DAPPER_WEBAPI_TELDA.Models
{
    public class UpdateUserAccount
    {
        public string Country { get; set; }
        public string State { get; set; }
        public string LGA { get; set; }
        public string Photo { get; set; }
        public string ResidentialAddress { get; set; }
        public bool isUpdated { get; set; }
    }
}
