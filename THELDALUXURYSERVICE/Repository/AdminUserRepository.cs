using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using Dapper;

namespace THELDALUXURYSERVICE.Repository
{
    public class AdminUserRepository
    {
        private readonly IDbConnection _DBCONNECTION;
        public AdminUserRepository(IDbConnection dbconnection)
        {
            _DBCONNECTION = dbconnection;
            //conString = @"Data Source = SOLDIERBOY\MSSQLMUSTY; Initial Catalog = theldaluxury; Integrated Security = True";
        }

        public void Add(tb_AdminUser adminUser)
        {

            using (_DBCONNECTION)
            {
                string sQuery = @"INSERT INTO tb_AdminUser (FirstName,LastName,OtherName,EmailAddress,PhoneNumber,UserName,Password,Photo,RoleId,ResidentialAddress) VALUES(@FirstName, @LastName, @OtherName, @EmailAddress, @PhoneNumber, @UserName, @Password, @Photo, @RoleId, @ResidentialAddress)";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, adminUser);
            }
        }

        public IEnumerable<tb_AdminUser> GetAll()
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_AdminUser";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_AdminUser>(sQuery);
            }
        }

        public tb_AdminUser GetAllById(int adminId)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_AdminUser WHERE AdminId = @adminId";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_AdminUser>(sQuery, new { Id = adminId }).FirstOrDefault();
            }
        }

        public void Delete(int adminId)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"DELETE FROM tb_AdminUser WHERE AdminId = @adminId";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, new { Id = adminId });
            }
        }

        public void Update(tb_AdminUser adminUser)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"UPDATE tb_AdminUser SET FirstName = @FirstName, LastName = @LastName, OtherName = @OtherName, EmailAddress = @EmailAddress, PhoneNumber = @PhoneNumber, Photo = @Photo, RoleId = @RoleId, ResidentialAddress = @ResidentialAddress WHERE AdminId = @AdminId";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, adminUser);
            }
        }
    }
}
