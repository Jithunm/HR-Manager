using HR_Manager.Controllers.Subs;
using HR_Manager.DBContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HR_Manager.Repository
{ 
    public interface IEmployeeRepository
    {
       IEnumerable<TBL_HR_Employee> GetEmployees();
        string InsertEmployee(TBL_HR_Employee model);
        TBL_HR_Employee GetEmployeeByID(string id);
        string UpdateEmployee(TBL_HR_Employee model);
        string DeleteEmployee(string empid);
        
    }
    public class EmployeeRepository 
    {
        EmployeeContext context = new EmployeeContext();
        MessageBox messageboxObj = new MessageBox();
       
        
        public IEnumerable<TBL_HR_Employee> GetEmployees()
        {
            var employeeData = context.TBL_EMPLOYEE.ToList();
            return employeeData;
        }
       public string InsertEmployee(TBL_HR_Employee model)
        {
            context.TBL_EMPLOYEE.Add(model);
            context.SaveChanges();
            return messageboxObj.successMessage1;
        }
        public TBL_HR_Employee GetEmployeeID(string empid)
        {
            var dataset = context.TBL_EMPLOYEE.Where(x => x.EmpID == empid).FirstOrDefault();
            return dataset;
        }
        public string UpdateEmployee(TBL_HR_Employee model)
        {
            var dataset = GetEmployeeID(model.EmpID);
            try
            {
                dataset.EmpFirstName = model.EmpFirstName;
                dataset.EmpLastName = model.EmpLastName;
                dataset.EmpDepartment = model.EmpDepartment;
                dataset.EmpDOJ = model.EmpDOJ;
                context.SaveChanges();
                
            }
            catch(Exception)
            {
                return (messageboxObj.updateError);
            }
            return (messageboxObj.successMessage1);

        }
        public string DeleteEmployee(string empid)
        {
            try
            {
                var dataset = context.TBL_EMPLOYEE.Where(x => x.EmpID == empid).FirstOrDefault();
                context.TBL_EMPLOYEE.Remove(dataset);
                context.SaveChanges(); 
            }
            catch(Exception)
            {
                return messageboxObj.deleteError;
            }

            return messageboxObj.deleteSuccess;
        }

    }
}