using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
    public class RegisterNewUserViewModel : ChangeUserViewModel
    {
        [Display(ResourceType = typeof(Strings), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMin")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "PasswordConfirm")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMin")]
        [Compare("Password", ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorPasswordCompare")]
        public string PasswordConfirm { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "IsAvailabe")]
        public bool IsAvailabe { get; set; }

    }
}
