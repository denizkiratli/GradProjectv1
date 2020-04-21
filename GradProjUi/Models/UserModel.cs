using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace GradProjUi.Models
{
    public class UserModel
    {
        [Display(Name = "Institution ID")]
        [Required(ErrorMessage ="You need to type your ID.")]
        public int UserId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "You need to type your name.")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [Required(ErrorMessage = "You need to type your last name.")]
        public string LastName { get; set; }

        [Display(Name = "E-Mail Address")]
        [Required(ErrorMessage = "You need to type your e-mail address.")]
        [DataType(DataType.EmailAddress)]
        public string MailAddress { get; set; }

        [Display(Name = "Confirm Your E-Mail Address")]
        [DataType(DataType.EmailAddress)]
        [Compare("MailAddress", ErrorMessage = "The addresses does not match.")]
        public string ConfirmMail { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "You need to type your password.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "Confirm Your Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "The passwords does not match.")]
        public string ConfirmPassword { get; set; }

    }
}