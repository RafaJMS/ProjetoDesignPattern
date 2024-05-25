using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlmoxarifadoInfrastructure.Data.Connections
{
    public class DbConnectionManager
    {
        private readonly IEnumerable<IDbConnectionStrategy> _strategies;

        public DbConnectionManager(IEnumerable<IDbConnectionStrategy> strategies)
        {
            _strategies = strategies;
        }

        public string GetActiveConnectionString()
        {
            foreach (var strategy in _strategies)
            {
                try
                {
                    return strategy.GetConnectionString();
                }
                catch (InvalidOperationException)
                {
                    
                }
            }
            throw new InvalidOperationException("All connection strategies failed.");
        }
    }
}