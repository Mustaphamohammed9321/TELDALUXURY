using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;

namespace TELDALUXURY_WEBSITE.Common
{
    public class ConnectionString
    {
        public string ConString()
        {
            return WebConfigurationManager.ConnectionStrings["teldaConnectionString"].ConnectionString;
            //return "Data Source = SIDSOFT-LAP-48\\MUSTY; Initial Catalog = theldaluxury; Integrated Security = True";
        }
    }
}