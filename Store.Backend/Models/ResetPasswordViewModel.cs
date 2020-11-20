using Store.Common.Resources;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Store.Backend.Models
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorEmail")]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMin")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "PasswordConfirm")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMin")]
        [Compare("Password", ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorPasswordCompare")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string Token { get; set; }

    }
}
