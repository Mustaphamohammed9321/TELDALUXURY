using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace THELDALUXURYECOMMERCE
{
    public class GlobalVariables
    {
        public static HttpClient WebApiClient = new HttpClient();

        GlobalVariables()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44373/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            
        }
    }
} 
