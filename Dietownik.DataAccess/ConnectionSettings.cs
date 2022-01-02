using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dietownik.DataAccess
{
    public class ConnectionSettings
    {
        private readonly IConfiguration configuration;

        public static string ConnectionString { get; set; }
        public ConnectionSettings(IConfiguration configuration)
        {
            this.configuration = configuration;
            ConnectionString = configuration.GetConnectionString("RecipeDatabaseConnection");
        }
    }
}
