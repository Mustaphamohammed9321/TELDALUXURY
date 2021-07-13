using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
namespace TELDALUXURY
{
    public class ConnectionString
    {
        public string ConString()
        {
            //return WebConfigurationManager.ConnectionStrings["teldaConnectionString"].ConnectionString;

            //return _configuration.GetConnectionString("DefaultConnection");
            return "Data Source = SIDSOFT-LAP-48\\MUSTY; Initial Catalog = theldaluxury; Integrated Security = True";
        }
    }
}
