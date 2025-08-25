using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MariApps.MS.Common.MSA.Employee.Business.Contracts;
using MariApps.MS.Common.MSA.Employee.DataModel;
using MariApps.MS.Common.MSA.Employee.DataCarrier;

namespace MariApps.MS.Common.MSA.Employee.ApiService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeServiceController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;
        public EmployeeServiceController(IEmployeeService employeeService,ILogger<EmployeeServiceController> logger )
        {
            _employeeService = employeeService;
        }


        [HttpGet("getemp")]
        public async Task<EmployeeEntity[]> getEmployee()
        {
            return await _employeeService.getEmployee();
        }

        [HttpGet("getemployeeId")]
        public async Task<EmployeeEntity>  getEmployeeID(int id) 

        {
            return await _employeeService.getEmployeeID(id);
        }

        [HttpPost("createEmployee")]
        public async Task createEmployee(EmployeeDT employee) 
        {
            await _employeeService.createEmployee(employee);

        }

        [HttpDelete("deleteEmployee")]
        public async Task deleteEmployee(int id)
        {
            await _employeeService.deleteEmployee(id);

        }
       [HttpPut("updateEmployee")]
        public async Task updateEmployee(EmployeeDT emp)
        {
            await _employeeService.updateEmployee(emp);

        }

    }
}
