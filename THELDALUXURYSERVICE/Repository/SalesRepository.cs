using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using THELDALUXURYECOMMERCE.Models;
using Dapper;

namespace THELDALUXURYSERVICE.Repository
{
    public class SalesRepository
    {
        private readonly IDbConnection _DBCONNECTION;
        public SalesRepository(IDbConnection dbconnection)
        {
            _DBCONNECTION = dbconnection;
        }
            public void Add(tb_Sales salesrole)
            {
                using (_DBCONNECTION)
                {
                    string sQuery = @"INSERT INTO tb_Sales (Item, ItemId, StatusId, Date) VALUES(@Item, @ItemId, @StatusId, @Date)";
                    _DBCONNECTION.Open();
                    _DBCONNECTION.Execute(sQuery, salesrole);
                }
            }

            public IEnumerable<tb_Sales> GetAll()
            {
                using (_DBCONNECTION)
                {
                    string sQuery = @"SELECT * FROM tb_Sales";
                    _DBCONNECTION.Open();
                    //tb_Sales sales = new tb_Sales();
                    return _DBCONNECTION.Query<tb_Sales>(sQuery);
                }
            }

            public tb_Sales GetAllById(int id)
            {
                using (_DBCONNECTION)
                {
                    string sQuery = @"SELECT * FROM tb_Sales WHERE SalesId = @Id";
                    _DBCONNECTION.Open();
                    return _DBCONNECTION.Query<tb_Sales>(sQuery, new { Id = id }).FirstOrDefault();
                }
            }

            public void Delete(int id)
            {
                using (_DBCONNECTION)
                {
                    string sQuery = @"DELETE FROM tb_Sales WHERE SalesId = @Id";
                    _DBCONNECTION.Open();
                    _DBCONNECTION.Execute(sQuery, new { Id = id });
                }
            }

            public void Update(tb_Sales salesrole)
            {
                using (_DBCONNECTION)
                {
                    string sQuery = @"UPDATE tb_Sales SET Item = @Item, ItemId = @ItemId, StatusId = @StatusId, Date = @Date WHERE SalesId = @SalesId";
                    _DBCONNECTION.Open();
                    _DBCONNECTION.Execute(sQuery, salesrole);
                }
            }
        }
    }