using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;

namespace BuyAtYourPrice.Web.Models
{
    public class SignUpModel
    {
        [Display(Name = "Logon name"), Required]
        [CustomValidation(typeof (AccountValidation), "CheckUserName")]
        public string UserName { get; set; }

        [Display(Name = "Email address"), Required, ValidateEmailAddress]
        public string Email { get; set; }

        [Display(Name = "Full name"), Required]
        public string FullName { get; set; }

        [Display(Name = "Password"), Required]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
    }
}