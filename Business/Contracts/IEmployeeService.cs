using MariApps.MS.Common.MSA.Employee.DataCarrier;
using MariApps.MS.Common.MSA.Employee.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MariApps.MS.Common.MSA.Employee.Business.Contracts
{
   public  interface IEmployeeService
    {
        Task<EmployeeEntity[]> getEmployee();

        Task<EmployeeEntity> getEmployeeID(int Id);
        
         Task createEmployee(EmployeeDT emp);
        
        Task deleteEmployee(int id);
        Task updateEmployee(EmployeeDT emp);
    }
}
