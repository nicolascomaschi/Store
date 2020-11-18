using Microsoft.AspNetCore.Identity;
using Store.Common.Enums;
using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Store.Common.Data.Entities
{
    public class User : IdentityUser
    {
        [MaxLength(50, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        public string FirstName { get; set; }

        [MaxLength(50, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        public string LastName { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "FullName")]
        public string FullName => $"{this.FirstName} {this.LastName}";

        [Display(ResourceType = typeof(Strings), Name = "Address")]
        [MaxLength(256, ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorStringMax")]
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        public string Address { get; set; }

        [Display(ResourceType = typeof(Strings), Name = "UserType")]
        public UserType UserType { get; set; }

        [NotMapped]
        [Display(ResourceType = typeof(Strings), Name = "IsGuest")]
        public bool IsGuest { get; set; }
    }
}
