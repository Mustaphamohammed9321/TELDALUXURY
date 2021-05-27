using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace THELDALUXURYSERVICE.Repository
{
    public class StateRepository: iStateRepository
    {
        private IDbConnection dbConnection;

        public StateRepository(IConfiguration configuration)
        {
            this.dbConnection = new SqlConnection(configuration.GetConnectionString("ConnectionName"));
        }
    }
}
