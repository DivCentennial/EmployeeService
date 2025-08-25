using MariApps.MS.Common.MSA.Employee.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariApps.MS.Common.MSA.Employee.Repository.Contracts.Repositories
{
   public  interface IEmployeeRepository
    {
      Task<IEnumerable<EmployeeDT>> getEmployee();
            
        Task<EmployeeDT> getEmployeeID(int Id);            
        
         Task createEmployee(EmployeeDT emp);
        Task deleteEmployee(int id);
       Task updateEmployee(EmployeeDT emp);

        
    }
}
