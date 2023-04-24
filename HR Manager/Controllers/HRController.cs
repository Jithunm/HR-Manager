using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Manager.Models;
using HR_Manager.Controllers.Subs;
using HR_Manager.Repository;
using HR_Manager.DBContexts;
using System.Threading.Tasks;

namespace HR_Manager.Controllers
{
    [Authorize]
    public class HRController : Controller
    { 
        EmployeeRepository empRepo = new EmployeeRepository();
        DateTime currentdate = DateTime.Now;
        Guid obj = Guid.NewGuid();
        MessageBox messageObj = new MessageBox();
        DepartmentLoader deptObj = new DepartmentLoader();
       
    public async Task<ActionResult> EmployeeView()
        {
          
            IEnumerable<TBL_HR_Employee> employeeData = await empRepo.GetEmployees();
            return View(employeeData);
        }
        [HttpGet]
        public ActionResult EmployeeInsert() {
            ViewBag.data = deptObj.DepartMentLoader();
            return View();
        }

        [HttpPost]
        public async Task<ActionResult> EmployeeInsert(TBL_HR_Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tempid = obj.ToString();
                    model.EmpID = tempid;
                    
                    return RedirectToAction("EmployeeView", TempData["Message"] =await empRepo.InsertEmployee(model));
                }
                else
                {
                    ViewBag.data = deptObj.DepartMentLoader();
                    return View();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(messageObj.updateError);
                return RedirectToAction("EmployeeView", TempData["Message"] = messageObj.insertError);

            }
            
        }
        [HttpGet]
        public async Task<ActionResult> EmployeeEdit(string empid)
        {
            ViewBag.data = deptObj.DepartMentLoader();   
            return View(await empRepo.GetEmployeeByID(empid));
        }
        [HttpPost]
        public async Task<ActionResult> EmployeeEdit(TBL_HR_Employee model)
        {
            
                try
                {
                    if (ModelState.IsValid)
                    {   
                    return RedirectToAction("EmployeeView", TempData["Message"] = await empRepo.UpdateEmployee(model));
                    }
                 else
                    {
                    return RedirectToAction("EmployeeView", TempData["Message"] = messageObj.updateError);
                    }
                    
                }
                catch (Exception ex)
                {
                Logger.WriteLog(messageObj.updateError);
                    return RedirectToAction("EmployeeView", TempData["Message"] =  messageObj.updateError);
                }   
        } 
    
        public async Task<ActionResult> EmployeeDelete(string empid)
        { 
            Logger.WriteLog(messageObj.deletelogMessage);
            return RedirectToAction("EmployeeView",TempData["Message"]= await empRepo.DeleteEmployee(empid));
        }

    }
}