//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HR_Manager
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class TBL_HR_Employee
    {
        public string EmpID { get; set; }
        public int EmpRefID { get; set; }
        [Required]
        [Display(Name = "FirstName")]
        public string EmpFirstName { get; set; }
        [Required]
        [Display(Name = "LastName")]
        public string EmpLastName { get; set; }
        [Display(Name = "Department")]
        public string EmpDepartment { get; set; }
        [Required]
        [Display(Name = "Date Of Joining")]
        public string EmpDOJ { get; set; }
    }
}
