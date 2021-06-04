using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Protocols;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using System.IO;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using System.Web;
using WEBAPI;
using System.Configuration;

namespace THELDALUXURYSERVICE
{
    public class ConnectionBox
    {
        public ConnectionBox()
        {
            
        }
       
        //private string con;
        //IOptions<ConnectionString> myconnectionstring;

        //public ConnectionBox(IOptions<ConnectionString> mconnectionstring)
        //{
        //    myconnectionstring = mconnectionstring;
        //    con = myconnectionstring.Value.connection;
        //}
        //public static MySqlConnection Create()
        //{
        //    string connectionString = ConfigurationManager.AppSettings["..."];
        //    MySqlConnection conection = new MySqlConnection(Config.ConnectionStr);
        //    connection.Open();
        //    return connection;
        //}

        //public IConfigurationRoot GetConfiguration()
        //{
        //    var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
        //    return builder.Build();
        //}



    }
   
}
