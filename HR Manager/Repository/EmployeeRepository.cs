using HR_Manager.Controllers.Subs;
using HR_Manager.DBContexts;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace HR_Manager.Repository
{ 
    public interface IEmployeeRepository
    {
        Task<IEnumerable<TBL_HR_Employee>> GetEmployees();
        Task<string> InsertEmployee(TBL_HR_Employee model);
        public Task<TBL_HR_Employee> GetEmployeeByID(string empid);
        Task<string> UpdateEmployee(TBL_HR_Employee model);
        Task<string> DeleteEmployee(string empid);
        
    }
    public class EmployeeRepository :IEmployeeRepository
    {
        EmployeeContext context = new EmployeeContext();
        MessageBox messageboxObj = new MessageBox();
       
        
        public async Task<IEnumerable<TBL_HR_Employee>> GetEmployees()
        {
            var employeeData = await (context.TBL_EMPLOYEE.ToListAsync());
            return employeeData;
        }
       public async Task<string> InsertEmployee(TBL_HR_Employee model)
        {
            context.TBL_EMPLOYEE.Add(model);
            await(context.SaveChangesAsync());
            return messageboxObj.successMessage1;
        }
        public async Task<TBL_HR_Employee> GetEmployeeByID(string empid)
        {
            var dataset =await (context.TBL_EMPLOYEE.Where(x => x.EmpID == empid).FirstOrDefaultAsync());
            return dataset;
        }
        public async Task<string> UpdateEmployee(TBL_HR_Employee model)
        {
            var dataset = await GetEmployeeByID(model.EmpID);
            try
            {
                dataset.EmpFirstName = model.EmpFirstName;
                dataset.EmpLastName = model.EmpLastName;
                dataset.EmpDepartment = model.EmpDepartment;
                dataset.EmpDOJ = model.EmpDOJ;
                await (context.SaveChangesAsync());
                
            }
            catch(Exception)
            {
                return (messageboxObj.updateError);
            }
            return (messageboxObj.updateSuccess);

        }
        public async Task<string> DeleteEmployee(string empid)
        {
            try
            {
                var dataset = context.TBL_EMPLOYEE.Where(x => x.EmpID == empid ).FirstOrDefault();
                context.TBL_EMPLOYEE.Remove(dataset);
                await (context.SaveChangesAsync()); 
            }
            catch (Exception) { 
                return messageboxObj.deleteError;
            }

            return messageboxObj.deleteSuccess;
        }

    }
}