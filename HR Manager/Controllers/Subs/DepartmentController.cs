using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Manager.Controllers.Subs
{
    public class DepartmentController : Controller
    {
        // GET: Department
        DB_HR_ManagerContext context = new DB_HR_ManagerContext();
        public List<TBL_HR_Department> DepartMentLoader()
        {
            var incomeitems = context.TBL_HR_Department.ToList();   
            return incomeitems;
        }
    }
}