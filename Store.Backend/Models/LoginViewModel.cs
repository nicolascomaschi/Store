using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
    public class LoginViewModel
    {
        [Display(ResourceType = typeof(Strings), Name = "Email")]
        [EmailAddress(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorEmail")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string UserName { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Password")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMin")]
        public string Password { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "RememberMe")]
        public bool RememberMe { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "IsAvailabe")]
        public bool IsAvailabe { get; set; }
    }
}
