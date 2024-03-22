using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Progetto_PrestitoLibri.Utilities
{
    internal class Config
    {
        private static Config? istanza;
        private string? connectionString;

        public static Config getIstanza()
        {
            if (istanza == null)
                istanza = new Config();

            return istanza;
        }
        Config(){}

        public string? GetConnectionString()
        {
            if (connectionString is null)
            {
                ConfigurationBuilder builder = new ConfigurationBuilder();
                builder.SetBasePath(Directory.GetCurrentDirectory());
                builder.AddJsonFile("appSettings.json", optional: false, reloadOnChange: false);

                IConfiguration configuration = builder.Build();
                connectionString = configuration.GetConnectionString("ServerLocale");
            }

            return connectionString;
        }
    }
}
