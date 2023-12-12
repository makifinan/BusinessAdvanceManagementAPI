using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessAdvanceManagement.Core.Helpers.Connection
{
    public class ConnectionHelper
    {
        private readonly IConfiguration _configuration;
        string connectionString = null;
        public ConnectionHelper(IConfiguration configuration)
        {
            _configuration = configuration;
            connectionString = configuration.GetConnectionString("AdvanceConnection");
        }

        public IDbConnection CreateConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
