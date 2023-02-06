using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HR_Manager.Models
{
    public class SignUpModel
    {
        [Key]
        public int id { get; set; }
        [Required]
        [Display(Name="Name")]
        public string name { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.EmailAddress)]
        public string email { get; set; }
        [Required]
        [Display(Name = "Name")]
        [DataType(DataType.Password)]
        public string password { get; set; }
    }
}