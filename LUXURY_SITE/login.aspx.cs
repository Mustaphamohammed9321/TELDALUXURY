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
            //_userepo = new UsersRepo();
        }
        public IDbConnection dbconnection
        {
            get
            {
                return new SqlConnection(connectionstring);
            }
        }

        public void UserSignIn(string email, string password)
        {
            email = txtemail.Text;
            password = txtpassword.Text;

            int operationtype = Convert.ToInt32(OperationType.UserLogin);
            try
            {
                using (dbconnection)
                {
                    DynamicParameters param = new DynamicParameters();
                    param.Add("@OperationType", operationtype);
                    param.Add("EmailAddress", email);
                    param.Add("Password", password);
                    //var output = dbconnection.Execute("SP_USERS", param, commandType: CommandType.StoredProcedure);
                    var res = dbconnection.Query<mvcUsers>("SP_USERS", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                 
                    if (res != null)
                        Response.Redirect("~/Index.aspx");
                    //lblErrorMsg.Text = "Email or Password incorrect, please try again";
                    //Response.Write("<script>swal('Good job!', 'You clicked the button!', 'error')</ script>");
                    Response.Write("<script>alert('Opps! Login Error, please try again')</script>");
                    //return res;
                }//end using
            }//end try
            catch (Exception ex)
            {
                Response.Write("<script>alert('Opps! Login Error"+ex.Message.ToString()+", please try again')</script>");
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
            //Login(txtemail.Text, txtpassword.Text);
            UserSignIn(txtemail.Text, txtpassword.Text);
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