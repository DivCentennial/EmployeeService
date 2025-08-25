using MariApps.MS.Common.MSA.Employee.Repository.Contracts.DbContext;
using MariApps.PAL.Framework.DataAccess;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariApps.MS.Common.MSA.Employee.Repository.DbContext
{
    public class AdoDbContext : BaseDBContext, IAdoDbContext
    {
        public AdoDbContext(string connectionString, ILogger<AdoDbContext> logger) 
            : base(connectionString, logger)
        {

        }
    }
}
