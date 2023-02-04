using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HR_Manager.Controllers.Subs
{
    public class MessageController : Controller
    {


        public string successMessage1 = "Employee Added Successfully!";
        public  string successMessage2 = "Data Updated Successfully!";
        public string errorMessage1 = "Data not Inserted! Check logs for further details";
        public string errorMessage2 = "Data not Updated! Check logs for further details";
        public string deleteMessage1 = "Data deletion Success!";
        public string deleteMessage2 = "Data deletion failed! Check logs for further details";
       

    }
}