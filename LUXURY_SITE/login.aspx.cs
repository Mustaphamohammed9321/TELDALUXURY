using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LUXURY_SITE.Repository;
using Dapper;
using LUXURY_SITE.Common;
using System.Data.Common;
using LUXURY_SITE.Models;
using System.Data;
using System.Data.SqlClient;

namespace LUXURY_SITE
{
    public partial class login : System.Web.UI.Page
    {
        private string connectionstring;

        ConnectionString con = new ConnectionString();
        Encryption crypt = new Encryption();

        private readonly UsersRepo _userepo;
        public login()
        {
            connectionstring = con.ConString();
            _userepo = new UsersRepo();
        }
        public IDbConnection dbconnection
        {
            get
            {
                return new SqlConnection(connectionstring);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {

            //if (IsPostBack)
            //{
            //    Response.Redirect("~/Index.aspx");
            //}
        }

        protected void SignIn(object sender, EventArgs e)
        {
           
            int signinresponse = _userepo.UserSignIn(txtemail.Text, txtpassword.Text);

            switch (signinresponse)
            {
                case 0:  //login failed
                    //Response.Write("<script>alert('Opps! Login Error, please try again')</script>");
                    lblErrorMsg.Text = "Email or Password incorrect, please try again";
                    txtemail.Text = txtpassword.Text = "";
                    break;
                case 1:  //login success
                    string firstname = _userepo.GetUserFirstName(txtemail.Text, txtpassword.Text);
                    Session["FirstName"] = firstname;
                    Response.Redirect("~/Index.aspx");
                    break;
            }
        }

        protected void btnsub_Click(object sender, EventArgs e)
        {
            ClientScript.RegisterStartupScript(this.GetType(), "random text", "alert()", true);
        }

        protected void txtemail_TextChanged(object sender, EventArgs e)
        {
            lblErrorMsg.Text = "";
        }
    }
}