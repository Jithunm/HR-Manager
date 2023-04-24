using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Manager.Models;
using HR_Manager.Controllers.Subs;
using HR_Manager.Repository;
using HR_Manager.DBContexts;

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
       
    public ActionResult EmployeeView()
        {
          
            IEnumerable<TBL_HR_Employee> employeeData = empRepo.GetEmployees();
            return View(employeeData);
        }
        [HttpGet]
        public ActionResult EmployeeInsert() {
            ViewBag.data = deptObj.DepartMentLoader();
            return View();
        }

        [HttpPost]
        public ActionResult EmployeeInsert(TBL_HR_Employee model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var tempid = obj.ToString();
                    model.EmpID = tempid;
                    
                    return RedirectToAction("EmployeeView", TempData["Message"] = empRepo.InsertEmployee(model));
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
        public ActionResult EmployeeEdit(string empid)
        {
            ViewBag.data = deptObj.DepartMentLoader();  
            return View(empRepo.GetEmployeeByID(empid));
        }
        [HttpPost]
        public ActionResult EmployeeEdit(TBL_HR_Employee model)
        {
            

                try
                {
                    if (ModelState.IsValid)
                    {   
                    return RedirectToAction("EmployeeView", TempData["Message"] = empRepo.UpdateEmployee(model));
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
    
        public ActionResult EmployeeDelete(string empid)
        { 
            Logger.WriteLog(messageObj.deletelogMessage);
            return RedirectToAction("EmployeeView",TempData["Message"]=empRepo.DeleteEmployee(empid));
        }

    }
}