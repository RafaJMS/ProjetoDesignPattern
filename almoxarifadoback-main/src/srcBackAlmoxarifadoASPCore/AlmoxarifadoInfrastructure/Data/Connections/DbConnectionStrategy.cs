using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Connections
{
    public class PrimaryDbConnectionStrategy : IDbConnectionStrategy
    {
        private readonly string _connectionString;

        public PrimaryDbConnectionStrategy(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            if (TestConnection(_connectionString))
            {
                return _connectionString;
            }
            throw new InvalidOperationException("Primary connection failed.");
        }

        private bool TestConnection(string connectionString)
        {
            try
            {
                using var connection = new SqlConnection(connectionString);
                connection.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }

    public class ReplicaDbConnectionStrategy : IDbConnectionStrategy
    {
        private readonly string _connectionString;

        public ReplicaDbConnectionStrategy(string connectionString)
        {
            _connectionString = connectionString;
        }

        public string GetConnectionString()
        {
            return _connectionString;
        }
    }

}
