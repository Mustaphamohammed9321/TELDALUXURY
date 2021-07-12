using System;
using System.Collections.Generic;
using System.Web.UI.WebControls;
//using TELDALUXURY_WEBSITE.Models;
using System.Net.Http;
using DAPPER_WEBAPI_TELDA.Models;
using WEBAPI.Models;



namespace TELDALUXURY_WEBSITE.Admin
{
    public partial class Index : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            IEnumerable<mvcUsers> slogin = null;

            HttpClient hc = new HttpClient();
            hc.BaseAddress = new Uri("https://localhost:44352/api/");   //load the API url here
            //hc.BaseAddress = new Uri("https://localhost:62162/api/");   //load the API url here
            var consume = hc.GetAsync("Users/GetUserName"); //add the controller name here
            consume.Wait();

            var readdata = consume.Result;
            if (readdata.IsSuccessStatusCode)
            {
                var disResult = readdata.Content.ReadAsAsync<IList<mvcUsers>>();
                disResult.Wait();
                slogin = disResult.Result;
                DropDownList1.DataSource = slogin;
                DropDownList1.DataTextField = "Users/GetUserName";
                DropDownList1.DataBind();
            }
        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void SqlDataSource1_Selecting(object sender, SqlDataSourceSelectingEventArgs e)
        {

        }


    }
}