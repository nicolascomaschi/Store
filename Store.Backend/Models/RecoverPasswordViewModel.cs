using Store.Common.Resources;
using System.ComponentModel.DataAnnotations;

namespace Store.Backend.Models
{
    public class RecoverPasswordViewModel
    {
        [Required(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorFieldRequired")]
        [EmailAddress(ErrorMessageResourceType = typeof(Strings), ErrorMessageResourceName = "ErrorEmail")]
        public string Email { get; set; }

    }
}
