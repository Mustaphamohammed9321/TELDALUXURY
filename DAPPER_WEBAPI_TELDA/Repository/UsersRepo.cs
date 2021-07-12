using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using TELDALUXURY_WEBSITE.Common;
using WEBAPI.Models;


namespace DAPPER_WEBAPI_TELDA.Repository
{
    public class UsersRepo
    {
        private string connectionstring;
        ConnectionString con = new ConnectionString();

        private List<mvcUsers> _users;
        public UsersRepo()
        {
            connectionstring = con.ConString();
        }
        public IDbConnection dbconnection
        {
            get
            {
                return new SqlConnection(connectionstring);
            }
        }

        public IEnumerable<GetUserFirstName> GetUserNames()  //get all user details 
        {
            //_users = new List<GetUserFirstName>();
            int operationtype = Convert.ToInt32(OperationType.GetFirstname);
            using (dbconnection)
            {
                dbconnection.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@OperationType", operationtype);
               return dbconnection.Query<GetUserFirstName>("SP_USERS", param,commandType:CommandType.StoredProcedure);
            }
        }


        public IEnumerable<mvcUsers> GetUsers()  //get all user details 
        {
            _users = new List<mvcUsers>();
            mvcUsers uLogin = new mvcUsers();
            int operationtype = Convert.ToInt32(OperationType.GetAllUsers);
            using (dbconnection)
            {
                dbconnection.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@OperationType", operationtype);
                var sLogin = dbconnection.Query<mvcUsers>("SP_USERS", param, commandType: CommandType.StoredProcedure).ToList();
                if (sLogin != null && sLogin.Count > 0)
                    _users = sLogin;
            }
            return _users;
        }

        public mvcUsers GetUserById(int Id)  //working
        {
            int operationType = Convert.ToInt32(OperationType.GetUserById);
            using (dbconnection)
            {
                dbconnection.Open();
                DynamicParameters param = new DynamicParameters();
                param.Add("@OperationType", operationType);
                param.Add("@Id", Id);
                var SLogin = dbconnection.Query<mvcUsers>("SP_USERS", param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                return SLogin;
            }
        }

        public void CreateUserAccount(CreateUserLogin userlogin)  //working 
        {
            ResponseMessage resp = new ResponseMessage();
            mvcUsers user = new mvcUsers();
            int operationType = Convert.ToInt32(OperationType.CreateUserAccount); //change update to stafflogin own 
            //add to check if user already exists with some certain details if user exst, dont add again
            using (dbconnection)
            {
                DynamicParameters parameters = new DynamicParameters();
                parameters.Add("@EmailAddress", userlogin.EmailAddress);
                parameters.Add("@Password", userlogin.Password);
                // parameters.Add("@PasswordHash", CStafflogin.Password);
                parameters.Add("@OperationType", operationType);
                if (dbconnection.State == ConnectionState.Closed)
                    dbconnection.Open();
                var slogin = dbconnection.Query<CreateUserLogin>("SP_USERS", parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public void DeleteStaffLoginDetails(int Id) //deleting a login is to make is inaccessible i.e isDeleted = 1
        {
            using (dbconnection)
            {
                var opt = GetUserById(Id);
                DynamicParameters param = new DynamicParameters();
                int operationtype = Convert.ToInt32(OperationType.DeleteUserAccount);
                param.Add("@Id", Id);
                param.Add("@OperationType", operationtype);
                if (dbconnection.State == ConnectionState.Closed)
                    dbconnection.Open();
                dbconnection.Execute("SP_USERS", param, commandType: CommandType.StoredProcedure);
            }
        }

        public void UpdateUserAccount(int id, UpdateUserAccount updateuser)
        {
            int operationType = Convert.ToInt32(OperationType.UpdateUserAccount);
            using (dbconnection)
            {
                DynamicParameters param = new DynamicParameters(); //create instance of dynamic parameters and dispose after use
                param.Add("@Operationtype", operationType); //insert the operation type for the stored procedure to use it
                param.Add("@Id", id);
                param.Add("@Country", updateuser.Country);
                param.Add("@State", updateuser.State);
                param.Add("@LGA", updateuser.LGA);
                param.Add("@Photo", updateuser.Photo);
                param.Add("@ResidentialAddress", updateuser.ResidentialAddress);
                if (dbconnection.State == ConnectionState.Closed)
                    dbconnection.Open();
                dbconnection.Execute("SP_USERS", param, commandType: CommandType.StoredProcedure);
            }
        }


    }
}