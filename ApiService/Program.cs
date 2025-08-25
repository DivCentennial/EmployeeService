
using MariApps.MS.Common.MSA.Employee.ApiService.Extensions;
using MariApps.Framework.ApiService.Core.DependencyInjection;
using MariApps.Framework.ApiService.Core.Middlewares;
using Microsoft.AspNetCore.Mvc;
using MariApps.Framework.Authorization.Services.Contract;
using MariApps.Framework.Caching;

namespace MariApps.MS.Common.MSA.Employee.ApiService
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.RegisterServiceDependecies();
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            builder.InitPalService();

            var app = builder.Build();

            app.MapPalCoreEndpoints();

            app.UsePalRequestPipeline(app.Environment);
           

            app.Run();

             

           
        }
    }
}