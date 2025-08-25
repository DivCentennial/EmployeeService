using MariApps.MS.Common.MSA.Employee.Business;
using MariApps.MS.Common.MSA.Employee.Business.Contracts;
using MariApps.MS.Common.MSA.Employee.Repository.Contracts.DbContext;
using MariApps.MS.Common.MSA.Employee.Repository.Contracts.Repositories;
using MariApps.MS.Common.MSA.Employee.Repository.DbContext;
using MariApps.MS.Common.MSA.Employee.Repository.Repositories;


namespace MariApps.MS.Common.MSA.Employee.ApiService.Extensions
{
    public static class DependencyRegistration
    {
        public static void RegisterServiceDependecies(this IServiceCollection services)
        {
            services.AddScoped<IAdoDbContext, AdoDbContext>(provider =>
            {
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();
                ILogger<AdoDbContext> logger = provider.GetRequiredService<ILogger<AdoDbContext>>();
                
                string? palConnectionString = configuration.GetConnectionString("PALConnectionString");

                if (string.IsNullOrEmpty(palConnectionString))
                    throw new ArgumentNullException("Connection string not found");

                return new AdoDbContext(palConnectionString, logger);
            });
            //services.AddScoped<ITransactionService, TransactionService>();
            //services.AddScoped<ITransactionRepository, TransactionRepository>();
            //services.AddScoped<ISampleRepository, SampleRepository>();
            services.AddScoped<IEmployeeService, EmployeeService>();
            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

        }
    }
}
