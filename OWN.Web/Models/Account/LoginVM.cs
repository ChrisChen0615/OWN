using System.ComponentModel.DataAnnotations;

namespace OWN.Web.Models.Account
{
    public class LoginVM
    {
        [Display(Name ="Email")]
        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "密碼")]
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name = "記住帳號?")]
        public bool RememberMe { get; set; }
    }
}
