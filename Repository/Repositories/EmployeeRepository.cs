using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MariApps.MS.Common.MSA.Employee.Repository.Contracts.Repositories;

using MariApps.MS.Common.MSA.Employee.Repository.Contracts.DbContext;
using Microsoft.Extensions.Logging;
using MariApps.MS.Common.MSA.Employee.DataModel;
using System.Data.SqlClient;

namespace MariApps.MS.Common.MSA.Employee.Repository.Repositories
{
    public class EmployeeRepository :IEmployeeRepository
    {
        private readonly IAdoDbContext _dbContext;
        private readonly ILogger<EmployeeRepository> _logger;
        public EmployeeRepository(IAdoDbContext dbContext, ILogger<EmployeeRepository> logger)
        {
            _dbContext = dbContext;
            _logger = logger;
        }

            

        async Task<IEnumerable<EmployeeDT>> IEmployeeRepository.getEmployee()
        {
            

            var result = await _dbContext.
            ExecuteAndMapEntityCollectionAsync<EmployeeDT>(SQLNamedQueries.STORED_PROC_USP_getEmployee);
           
            return result;
        }

        async Task<EmployeeDT> IEmployeeRepository.getEmployeeID(int id)
        {
            var sqlparam = new  { empid = id};
            var result = await _dbContext.
                ExecuteAndMapEntityAsync<EmployeeDT>(SQLNamedQueries.STORED_PROC_USP_getEmployeeID, sqlparam);
            
            return result;

        }

        async Task IEmployeeRepository.createEmployee(EmployeeDT emp)
        {
            
            var sqlParams = new { empid = emp.EmpNo,ena = emp.EName,sal = emp.Salary ,dno = emp.DeptNo,jdt = emp.JDate };
           

            await _dbContext.ExecuteCommandAsync(SQLNamedQueries.STORED_PROC_USP_createEmployee, sqlParams);

        }
        async Task IEmployeeRepository.deleteEmployee(int id)
        {
            var sqlParams = new { eno = id };
            await _dbContext.ExecuteCommandAsync(SQLNamedQueries.STORED_PROC_USP_deleteEmployee, sqlParams);
        }

        async Task IEmployeeRepository.updateEmployee(EmployeeDT emp)
        {
        

            var sqlParams = new { eno = emp.EmpNo,ena = emp.EName,sal = emp.Salary,dno = emp.DeptNo,jdt = emp.JDate };

            await _dbContext.ExecuteCommandAsync(SQLNamedQueries.STORED_PROC_USP_editEmployee, sqlParams);
        }


    }
}
