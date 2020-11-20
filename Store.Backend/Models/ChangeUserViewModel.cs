using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
    public class ChangeUserViewModel
    {
        [Display(ResourceType = typeof(Strings), Name = "FirstName")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string FirstName { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "LastName")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Username")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [MinLength(6, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMin")]
        public string Username { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Email")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorEmail")]
        public string Email { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "Address")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string Address { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "PhoneNumber")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string PhoneNumber { get; set; }
    }
}
