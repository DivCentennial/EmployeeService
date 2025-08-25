using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MariApps.MS.Common.MSA.Employee.Business.Contracts;
using MariApps.MS.Common.MSA.Employee.DataCarrier;
using MariApps.MS.Common.MSA.Employee.DataModel;
using MariApps.MS.Common.MSA.Employee.Repository.Contracts.Repositories;
using MariApps.MS.Common.MSA.Employee.Repository.Repositories;
using Microsoft.Extensions.Logging;

namespace MariApps.MS.Common.MSA.Employee.Business
{
    public class EmployeeService : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly ILogger<EmployeeService> _logger;
        public EmployeeService(ILogger<EmployeeService> logger, IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
            _logger = logger;
        }


        private EmployeeEntity GetEmployeeEntity(EmployeeDT modelEntity)
        {
            return new EmployeeEntity
            {

                EmpNo = modelEntity.EmpNo,
                EName = modelEntity.EName,
                Salary = modelEntity.Salary,
                DeptNo = modelEntity.DeptNo,
                JDate = modelEntity.JDate

            };
        }
       
        async Task<EmployeeEntity[]> IEmployeeService.getEmployee()
        {
            var tempResult = await _employeeRepository.getEmployee();
            var result = tempResult.Select(t => GetEmployeeEntity(t)).ToArray();

            return result;
        }

        public async Task<EmployeeEntity> getEmployeeID(int Id)
        {

            
            var tempResult = await _employeeRepository.getEmployeeID(Id);
            return GetEmployeeEntity(tempResult);
        }

        public async Task createEmployee(EmployeeDT emp)
        {
            await _employeeRepository.createEmployee(emp);
        }
        public async Task deleteEmployee(int id)
        {
            await _employeeRepository.deleteEmployee(id);
        }

        public async Task updateEmployee(EmployeeDT emp)
        {
            await _employeeRepository.updateEmployee(emp);
        }

    }
}
