using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Web.Models
{
    public class LoginModel
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
    }
}