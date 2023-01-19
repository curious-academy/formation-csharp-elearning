using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;

namespace HarryPotter.Games.Core.DataLayers
{
    internal abstract class DbDataLayer
    {
        protected string ConnectionString { get; private set; }

        protected DbDataLayer() 
        {
            IConfiguration configuration = new ConfigurationBuilder()
                                            .AddJsonFile("appsettings.json")
                                            .Build();

            this.ConnectionString = configuration.GetConnectionString("HarryPotter.Games.ConnectionString");
        }
    }
}
