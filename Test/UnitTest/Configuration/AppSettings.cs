using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariApps.MS.Common.MSA.Employee.Test.UnitTest.Configuration
{
    public static class AppSettings
    {
        public static IConfigurationRoot GetConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .AddInMemoryCollection(new Dictionary<string, string?>
                {
                    {
                        "ConnectionStrings:PALConnectionString", "data source=10.201.1.173\\ERP,1433; initial catalog=TRAINING; Integrated Security=true; MultipleActiveResultSets=True; Min Pool Size=25; Max Pool Size=2000; Connection Timeout=100;"
                    }
                });

            return builder.Build();
        }
    }
}
