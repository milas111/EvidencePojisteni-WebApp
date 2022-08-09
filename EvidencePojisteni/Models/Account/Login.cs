using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.Account
{
    public class Login
    {
        [Required(ErrorMessage = "Zadejte email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Zadejte heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Display(Name = "Zapamatovat si přihlašovací údaje")]
        public bool RememberMe { get; set; }
    }
}
