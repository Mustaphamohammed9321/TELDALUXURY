using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using Dapper;
using WEBAPI.Models;
using THELDALUXURYECOMMERCE.Response;

namespace THELDALUXURYSERVICE.Repository
{
    public class NewUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherName  {get; set;}
        public string StatusId   {get; set;}
        public string EmailAddress{get; set;}
        public string PhoneNumber {get; set;}
        public string UserName    {get; set;}
        public string Password    {get; set;}
        public string DateAdded { get; set; }
    }


    public class UsersRepository
    {
        private readonly IDbConnection _DBCONNECTION;
        public UsersRepository(IDbConnection dbConnection)
        {
            //connection string
            _DBCONNECTION = dbConnection;
        }


        //add user (with some certain information, i.e informations used for creating account)
        public void Add(tb_Users user)
        {
            using (_DBCONNECTION)
            {  //NB: ststusd here is 1 by default. 1=activeUser, 0=inActiveUser or deleted
                string sQuery = @"INSERT INTO tb_Users (FirstName,LastName,OtherName,StatusId,EmailAddress,PhoneNumber,UserName,Password,Country,State,LGA,Photo,ResidentialAddress,DateAdded) VALUES(@FirstName,@LastName,@OtherName,1,@EmailAddress,@PhoneNumber,@UserName,@Password,@Country,@State,@LGA,@Photo,@ResidentialAddress," + DateTime.UtcNow.Date.ToString() +" ";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, user);
            }
        }

        //Get all users
        public IEnumerable<tb_Users> GetAllUser()
        {
            //define amnt=amount of record to show and order=ASC
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_Users";
                _DBCONNECTION.Open();
                tb_Users adrole = new tb_Users();
                return _DBCONNECTION.Query<tb_Users>(sQuery);
            }
        }
        

        //Get all Updated Users(using statusID)
        public IEnumerable<tb_Users> GetUpdatedUser()
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_Users WHERE StatusId = 1";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_Users>(sQuery);
            }
        }        

        
        //Get all by Id
        public tb_Users GetAllById(int id)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_Users WHERE Id = @Id";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_Users>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        
       
        //Delete user from database  NB: shoudnt be so though, user should be sent into an archive table
        public void Delete(int id)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"DELETE FROM tb_Users WHERE Id = @Id";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, new { Id = id });
            }
        }

        
        //Update User personal info except photo
        public void Update(tb_Users users) 
        {
            using (_DBCONNECTION)
            {
                //create a new object that contains the fields for updating

                string sQuery = @"UPDATE tb_Users SET (FirstName = @FirstName, LastName = @LastName, OtherName = @OtherName, Country = @Country, State = @State, LGA = @LGA, ResidentialAddress = @ResidentialAddress) WHERE Id = @Id";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, users);
            }
        }


        //Add Userphoto
        public void AddUserPhoto(tb_Users userphoto)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"INSERT INTO tb_Users (Photo) VALUES(@Photo)";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, userphoto);
            }
        }
        


        //Update user photo only
        public void UpdateUserPhoto(tb_Users users)  //literarilly called change photo
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"UPDATE tb_Users SET Photo = @Photo";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, users);
            }
        }

    }
}
