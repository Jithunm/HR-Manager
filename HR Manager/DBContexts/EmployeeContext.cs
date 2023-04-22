using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HR_Manager.DBContexts
{
    public class EmployeeContext : DbContext
    {
        public EmployeeContext() : base("name=DB_HR_ManagerContext")
        {

        }
        public DbSet<TBL_HR_Employee> TBL_EMPLOYEE {get;set;}
    }
}