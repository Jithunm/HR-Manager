using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Manager.Models
{
    public partial class LoginModel
    {
        [Required]
        [Display(Name ="Email")]
        public string email { get; set; }
        [Required]
        [Display(Name = "PassWord")]
        public string password { get; set; }

    }
}