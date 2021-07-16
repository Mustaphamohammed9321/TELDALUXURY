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

namespace LUXURY_SITE.ADMINTEMPLATE
{
    public partial class Index : System.Web.UI.Page
    {
        private readonly UsersRepo _userepo;
        public Index()
        {
            _userepo = new UsersRepo();
        }

        //Get: api/Firstname
        //[HttpGet("GetUserFirstName")]
        public IEnumerable<GetUserFirstName> GetUserFirstName()
        {
            if (ModelState.IsValid)
                return _userepo.GetUserNames().ToList();
            //StatusCode(500, "Could not load data from database");
            return null;
        }


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
            lblYear.Text = DateTime.UtcNow.Year.ToString();
        }
    }
}