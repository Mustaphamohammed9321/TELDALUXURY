using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using THELDALUXURYECOMMERCE.Models;
using Dapper;

namespace THELDALUXURYSERVICE.Repository
{
    public class AdminRoleRepository
    {
        private readonly IDbConnection _DBCONNECTION;
        public AdminRoleRepository(IDbConnection dbconnection)
        {
            _DBCONNECTION = dbconnection;
            //conString = @"Data Source = SOLDIERBOY\MSSQLMUSTY; Initial Catalog = theldaluxury; Integrated Security = True";
        }

        public void Add(tb_AdminRole adminrole)
        {

            using (_DBCONNECTION)
            {
                string sQuery = @"INSERT INTO tb_AdminRole (Role, AdminId) VALUES(@Role, @AdminId)";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, adminrole);
            }
        }

        public IEnumerable<tb_AdminRole> GetAll()
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_AdminRole";
                _DBCONNECTION.Open();
                tb_AdminRole adrole = new tb_AdminRole();
                return _DBCONNECTION.Query<tb_AdminRole>(sQuery);

            }
        }
        public tb_AdminRole GetAllById(int id)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_AdminRole WHERE RoleId = @Id";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_AdminRole>(sQuery, new { Id = id }).FirstOrDefault();
            }
        }
        public void Delete(int id)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"DELETE FROM tb_AdminRole WHERE RoleId = @Id";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, new { Id = id });
            }
        }
        public void Update(tb_AdminRole adminrole)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"UPDATE tb_AdminRole SET Role = @Role, AdminId = @AdminId WHERE RoleId = @RoleId";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, adminrole);
            }
        }
    }
}
