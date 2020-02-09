using SIS.MvcFramework.Attributes.Validation;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyPanda.Web.ViewModels.Users
{
    public class LoginInputModel
    {
        [RequiredSis]
        [StringLengthSis(5,20, "Username must be between 5 and 20")]
        public string Username { get; set; }

        [RequiredSis]
        public string Password { get; set; }
    }
}
