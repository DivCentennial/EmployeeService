using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariApps.MS.Common.MSA.Employee.DataCarrier
{
  public   class EmployeeEntity
    {
        public int EmpNo { get; set; }
        public string? EName { get; set; }
        public int Salary { get; set; }
        public int DeptNo { get; set; }
        public DateTime JDate { get; set; }
    }
}
