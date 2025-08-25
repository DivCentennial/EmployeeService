using MariApps.MS.Common.MSA.Employee.DataModel;
using MariApps.MS.Common.MSA.Employee.Repository.Contracts.DbContext;
using MariApps.MS.Common.MSA.Employee.Repository.Contracts.Repositories;
using MariApps.MS.Common.MSA.Employee.Repository.DbContext;
using MariApps.MS.Common.MSA.Employee.Repository.Repositories;
using MariApps.MS.Common.MSA.Employee.Test.UnitTest.Configuration;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariApps.MS.Common.MSA.Employee.Test.UnitTest
{
    [TestClass]
    public class EmployeeRepositoryTest
    {
        [TestMethod]
        public void GetEmployeeDataIDTest()
        {
            //Arrange
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(AppSettings.GetConfiguration());

            services.AddScoped<IAdoDbContext, AdoDbContext>(provider =>
            {
                ILogger<AdoDbContext> logger = provider.GetRequiredService<ILogger<AdoDbContext>>();
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

                string? palConnectionString = configuration.GetConnectionString("PALConnectionString");

                if (string.IsNullOrEmpty(palConnectionString))
                    throw new ArgumentNullException("Connection string not found");

                return new AdoDbContext(palConnectionString, logger);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Act
            var serviceProvider = services.BuildServiceProvider();

            var employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            var result = employeeRepository.getEmployee().GetAwaiter().GetResult();

            //Assert
            Assert.AreEqual(6, result.Count());
            Assert.AreEqual(true, (result.First().EmpNo > 0));
        }



        [TestMethod]
        public void GetEmployeeDataTest()
        {
            //Arrange
            int no = 101;
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(AppSettings.GetConfiguration());

            services.AddScoped<IAdoDbContext, AdoDbContext>(provider =>
            {
                ILogger<AdoDbContext> logger = provider.GetRequiredService<ILogger<AdoDbContext>>();
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

                string? palConnectionString = configuration.GetConnectionString("PALConnectionString");

                if (string.IsNullOrEmpty(palConnectionString))
                    throw new ArgumentNullException("Connection string not found");

                return new AdoDbContext(palConnectionString, logger);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Act
            var serviceProvider = services.BuildServiceProvider();

            var employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            var result = employeeRepository.getEmployeeID(no).GetAwaiter().GetResult();

            Assert.AreNotEqual(result, null);
            Assert.AreEqual(true, (result.DeptNo >= 10));


        }

        [TestMethod]
        public void DeleteEmployeeDataTest()
        {
            //Arrange
            int no = 101;
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(AppSettings.GetConfiguration());

            services.AddScoped<IAdoDbContext, AdoDbContext>(provider =>
            {
                ILogger<AdoDbContext> logger = provider.GetRequiredService<ILogger<AdoDbContext>>();
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

                string? palConnectionString = configuration.GetConnectionString("PALConnectionString");

                if (string.IsNullOrEmpty(palConnectionString))
                    throw new ArgumentNullException("Connection string not found");

                return new AdoDbContext(palConnectionString, logger);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Act
            var serviceProvider = services.BuildServiceProvider();

            var employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            var result = employeeRepository.deleteEmployee(no);

            Assert.AreNotEqual(result, false);
           


        }


        [TestMethod]
        public void CreateEmployeeDataTest()
        {
            //Arrange
            var emp = new EmployeeDT()
            {
                EmpNo = 1,
                EName = "Rohi",
                Salary = 1000,
                DeptNo = 2,
                JDate = DateTime.Now

            };
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(AppSettings.GetConfiguration());

            services.AddScoped<IAdoDbContext, AdoDbContext>(provider =>
            {
                ILogger<AdoDbContext> logger = provider.GetRequiredService<ILogger<AdoDbContext>>();
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

                string? palConnectionString = configuration.GetConnectionString("PALConnectionString");

                if (string.IsNullOrEmpty(palConnectionString))
                    throw new ArgumentNullException("Connection string not found");

                return new AdoDbContext(palConnectionString, logger);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Act
            var serviceProvider = services.BuildServiceProvider();

            var employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            var result = employeeRepository.createEmployee(emp);

            Assert.AreNotEqual(result, false);
            //   Assert.AreEqual(10,result.);

        }

        [TestMethod]
        public void UpdateEmployeeDataTest()
        {
            //Arrange
            var emp = new EmployeeDT()
            {
                EmpNo = 101,
                EName = "Rohi",
                Salary = 1000,
                DeptNo = 2,
                JDate = DateTime.Now

            };
            var services = new ServiceCollection();
            services.AddLogging();
            services.AddSingleton<IConfiguration>(AppSettings.GetConfiguration());

            services.AddScoped<IAdoDbContext, AdoDbContext>(provider =>
            {
                ILogger<AdoDbContext> logger = provider.GetRequiredService<ILogger<AdoDbContext>>();
                IConfiguration configuration = provider.GetRequiredService<IConfiguration>();

                string? palConnectionString = configuration.GetConnectionString("PALConnectionString");

                if (string.IsNullOrEmpty(palConnectionString))
                    throw new ArgumentNullException("Connection string not found");

                return new AdoDbContext(palConnectionString, logger);
            });

            services.AddScoped<IEmployeeRepository, EmployeeRepository>();

            //Act
            var serviceProvider = services.BuildServiceProvider();

            var employeeRepository = serviceProvider.GetRequiredService<IEmployeeRepository>();
            var result = employeeRepository.updateEmployee(emp);

            Assert.AreNotEqual(result, false);
            //   Assert.AreEqual(10,result.);
           

        }
    }
}
