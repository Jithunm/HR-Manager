using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HR_Manager.Models;
using HR_Manager.Controllers.Subs;

namespace HR_Manager.Controllers
{
    
    public class HRController : Controller
    {

        DB_HR_ManagerContext context = new DB_HR_ManagerContext();
        DateTime currentdate = DateTime.Now;
        Guid obj = Guid.NewGuid();
        MessageBox messageObj = new MessageBox();
        DepartmentLoader deptObj = new DepartmentLoader();
       
    public ActionResult EmployeeView()
        {
            var employeeData = context.TBL_HR_Employee.ToList();
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
                    context.TBL_HR_Employee.Add(model);
                    context.SaveChanges();
                    return RedirectToAction("EmployeeView", TempData["Message"] = messageObj.successMessage1);
                }
                else
                {
                    ViewBag.data = deptObj.DepartMentLoader();
                    return View();
                }
            }
            catch (Exception ex)
            {
                Logger.WriteLog(messageObj.errorMessage2);
                return RedirectToAction("EmployeeView", TempData["Message"] = messageObj.errorMessage1);

            }
            
        }
        [HttpGet]
        public ActionResult EmployeeEdit(string empid)
        {
            ViewBag.data = deptObj.DepartMentLoader();
            var dataset = context.TBL_HR_Employee.Where(x => x.EmpID == empid).FirstOrDefault();
            return View(dataset);
        }
        [HttpPost]
        public ActionResult EmployeeEdit(TBL_HR_Employee model)
        {
            var dataset = context.TBL_HR_Employee.Where(x => x.EmpID == model.EmpID).FirstOrDefault();

                try
                {
                    if (ModelState.IsValid)
                    {
                        dataset.EmpFirstName = model.EmpFirstName;
                        dataset.EmpLastName = model.EmpLastName;
                        dataset.EmpDepartment = model.EmpDepartment;
                        dataset.EmpDOJ = model.EmpDOJ;

                        context.SaveChanges();
                        return RedirectToAction("EmployeeView", TempData["Message"] = messageObj.successMessage2);
                    }
                 else
                    {
                    return RedirectToAction("EmployeeView", TempData["Message"] = messageObj.errorMessage2);
                }
                    
                }
                catch (Exception ex)
                {
                Logger.WriteLog(messageObj.errorMessage2);
                    return RedirectToAction("EmployeeView", TempData["Message"] =  messageObj.errorMessage2);
                }   
        }
    
        public ActionResult EmployeeDelete(string empid)
        {
            var dataset = context.TBL_HR_Employee.Where(x => x.EmpID == empid).FirstOrDefault();
            context.TBL_HR_Employee.Remove(dataset);
            context.SaveChanges();
            Logger.WriteLog(messageObj.deletelogMessage);
            return RedirectToAction("EmployeeView",TempData["Message"]=messageObj.deletelogMessage);
        }

    }
}