using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.UI;
using System.Web.UI.WebControls;
using Dapper;
using LUXURY_SITE.Models;
using LUXURY_SITE.Repository;
using System.Data;
using Microsoft.Data.SqlClient;
using LUXURY_SITE.Common;

namespace LUXURY_SITE.ADMINTEMPLATE
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly UsersRepo _userepo;
        private string connectionstring;
        ConnectionString con = new ConnectionString();

        public Index()
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

        //Get: api/Firstname
        //[HttpGet("GetUserFirstName")]
        //public IEnumerable<GetUserFirstName> GetUserFirstName()
        //{
        //    if (ModelState.IsValid)
        //        return _userepo.GetUserFirstName().ToList();
        //    //StatusCode(500, "Could not load data from database");
        //    return null;
        //}


        // GET: api/Users
        //[HttpGet("AllUsers")]
        public IEnumerable<mvcUsers> GetUsers()
        {
            if (ModelState.IsValid)
                return _userepo.GetUsers().ToList();
            //StatusCode(500, "Could not load data from database");
            return null;
        }

        // GET: api/Users/5
        //[HttpGet("Userlogin/{id}")]
        public mvcUsers GetUserById(int id)
        {
            return _userepo.GetUserById(id);
        }

        // POST: api/Users
        //[HttpPost("CreateUserAccount")]
        public void CreateUserAccount([FromBody] CreateUserLogin user)
        {
            if (ModelState.IsValid)
                _userepo.CreateUserAccount(user);
            //StatusCode(500, "Could not add new customer, please try again");
        }

        // PUT: api/Users/5
        //[HttpPut("UpdateUser/{id}")]
        public void UpdateUser(int id, [FromBody] UpdateUserAccount updateuser)
        {
            if (ModelState.IsValid)
                _userepo.UpdateUserAccount(id, updateuser);
            //StatusCode(500, "Update failed, please try again");
        }


        // DELETE: api/Users/5
        //[HttpDelete("RemoveUserAccount/{id}")]
        public void Delete(int id)
        {
            try
            {
                _userepo.DeleteStaffLoginDetails(id);
            }
            catch (Exception ex)
            {
                ex.Message.ToString();
            }
        }
        
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["FirstName"] == null)
            {
                Response.Redirect("~/login.aspx");
            }

            lblYear.Text = DateTime.UtcNow.Year.ToString();
            lblFirstname.Text = Session["Firstname"].ToString();
        }

       
        protected void btnLogOut_Click(object sender, EventArgs e)
        {
            Session.Clear();  //just clear the sesson and user doesnt need to sign in again
            Session.Abandon();  //user has to login again
            Response.Redirect("~/login.aspx");
        }
    }
}