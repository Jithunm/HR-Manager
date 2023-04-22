using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Manager.Controllers.Subs
{
    public class MessageBox
    {
        public string successMessage1 = "Employee Added Successfully!";
        public  string successMessage2 = "Data Updated Successfully!";
        public string insertError = "Data not Inserted! Check logs for further details";
        public string updateError = "Data not Updated! Check logs for further details";
        public string deleteSuccess = "Data deletion Success!";
        public string deleteError = "Data deletion failed! Check logs for further details";
        public string deletelogMessage = "Employee deleted sucessfully";
        public string signUpSuccess = "Registration is successfull! Try Login with Credentials!";
        public string signUpSuccessLog = "New user account created with UserName :";
        public string signUpErrorLog = "Account creation failed! Provide valid UserName and PassWord. If the issue still persists, please check logs";

    }
}