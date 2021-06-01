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
    public class StateRepository
    {
        //private IConfiguration configuration;

        private string conString;   
        public StateRepository(/*IConfiguration _configuration*/)
        {
            //string conString1 = this.configuration.GetConnectionString("connectionName");            
            //connectionstring = @"SOLDIERBOY\MSSQLMUSTY; Initial Catalog=theldaluxury; Integrated Security = True";
            conString = @"Data Source = SOLDIERBOY\MSSQLMUSTY; Initial Catalog = theldaluxury; Integrated Security = True";
        }
        private  IDbConnection connection
        {
            get
            {
                return new SqlConnection(conString);
            }
        }

        public void Add(tb_State state)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"INSERT INTO tb_State (StateName, CountryId) VALUES(@StateName, @CountryId)";
                dbConnection.Open();
                dbConnection.Execute(sQuery, state);
            }
        } 
        
        public IEnumerable<tb_State> GetAll()
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"SELECT * FROM tb_State";
                dbConnection.Open();
                return dbConnection.Query<tb_State>(sQuery);
            }
        }
        
        public tb_State GetAllById(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"SELECT * FROM tb_State WHERE StateId = @Id";
                dbConnection.Open();
                return dbConnection.Query<tb_State>(sQuery, new { Id = id }).FirstOrDefault();
            }
        } 
        
        public void Delete(int id)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"DELETE FROM tb_State WHERE StateId = @Id";
                dbConnection.Open();
                dbConnection.Execute(sQuery, new { Id = id });
            }
        }

        public void Update(tb_State state)
        {
            using (IDbConnection dbConnection = connection)
            {
                string sQuery = @"UPDATE tb_State SET StateName = @StateName, CountryId = @CountryId WHERE StateId = @StateId";
                dbConnection.Open();
                dbConnection.Execute(sQuery, state);
            }
        }


    }
}
