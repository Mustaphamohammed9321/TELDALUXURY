using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using THELDALUXURYECOMMERCE.Models;
using Dapper;
using Microsoft.IdentityModel.Protocols;

namespace THELDALUXURYSERVICE.Repository
{
    public class StateRepository
    {        
        private readonly IDbConnection _DBCONNECTION;
        public StateRepository(IDbConnection dbconnection)
        {
            _DBCONNECTION = dbconnection;
            //conString = @"Data Source = SOLDIERBOY\MSSQLMUSTY; Initial Catalog = theldaluxury; Integrated Security = True";
        }

        public void Add(tb_State state)
        {
            
            using (_DBCONNECTION)
            {
                string sQuery = @"INSERT INTO tb_State (StateName, CountryId) VALUES(@StateName, @CountryId)";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, state);
            }
        } 
        
        public IEnumerable<tb_State> GetAll()
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_State";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_State>(sQuery);
            }
        }
        
        public tb_State GetAllById(int id)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"SELECT * FROM tb_State WHERE StateId = @Id";
                _DBCONNECTION.Open();
                return _DBCONNECTION.Query<tb_State>(sQuery, new { Id = id }).FirstOrDefault();
            }
        } 
        
        public void Delete(int id)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"DELETE FROM tb_State WHERE StateId = @Id";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(tb_State state)
        {
            using (_DBCONNECTION)
            {
                string sQuery = @"UPDATE tb_State SET StateName = @StateName, CountryId = @CountryId WHERE StateId = @StateId";
                _DBCONNECTION.Open();
                _DBCONNECTION.Execute(sQuery, state);
            }
        }


    }
}