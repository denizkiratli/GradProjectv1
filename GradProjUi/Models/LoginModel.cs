using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjUi.Models
{
    public class LoginModel
    {
        [Display(Name ="E-Mail Address")]
        [Required(AllowEmptyStrings =false, ErrorMessage ="Please type your e-mail address.")]
        public string EMail { get; set; }
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [Required(AllowEmptyStrings = false, ErrorMessage = "Please type your password.")]
        public string Password { get; set; }
    }
}