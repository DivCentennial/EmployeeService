using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MariApps.MS.Common.MSA.Employee.Repository
{
    internal static class SQLNamedQueries
    {
       // public static string STORED_PROC_USP_DISTRIBUTEDTRANSACTION_COMMIT => "[Schema].[USP_DistributedTransaction_Commit]";
   //     public static string STORED_PROC_USP_DISTRIBUTEDTRANSACTION_ROLLBACK => "[Schema].[USP_DistributedTransaction_RollBack]";
        public static string STORED_PROC_USP_getEmployee => "[dbo].[getEmp]";
        public static string STORED_PROC_USP_getEmployeeID => "[dbo].[getEmpId]";
        public static string STORED_PROC_USP_createEmployee => "[dbo].[createEmp]";
        
        public static string STORED_PROC_USP_deleteEmployee => "[dbo].[deleteEmp ]";
        public static string STORED_PROC_USP_editEmployee => "[dbo].[updateEmp]";


    }
}
