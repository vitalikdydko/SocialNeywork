using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Web.Models
{
    public class RegisterModel
    {
        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                          ErrorMessageResourceName = "NameRequired")]

        [Display(Name = "Name", ResourceType = typeof(Resources.Resource))]
        public string UserName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                          ErrorMessageResourceName = "PasswordRequired")]

        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                        ErrorMessageResourceName = "PasswordRequired")]

        [Display(Name = "Password", ResourceType = typeof(Resources.Resource))]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Пароль подтвержден неверно")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                         ErrorMessageResourceName = "EmailRequired")]

        [Display(Name = "Email", ResourceType = typeof(Resources.Resource))]
        [RegularExpression(@"^[a-zA-Z0-9.-]{1,20}@[a-zA-Z0-9]{1,20}\.[A-Za-z]{2,4}",
            ErrorMessage = "Неверный формат Email")]
        public string Email { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                         ErrorMessageResourceName = "FirstNameRequired")]

        [Display(Name = "FirstName", ResourceType = typeof(Resources.Resource))]
        public string FirstName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                         ErrorMessageResourceName = "SecondNameRequired")]

        [Display(Name = "SecondName", ResourceType = typeof(Resources.Resource))]
        public string SecondName { get; set; }

        [Required(ErrorMessageResourceType = typeof(Resources.Resource),
                         ErrorMessageResourceName = "MiddleNameRequired")]

        [Display(Name = "MiddleName", ResourceType = typeof(Resources.Resource))]
        public string MiddleName { get; set; }
       
    }
}