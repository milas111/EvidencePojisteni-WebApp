using EvidencePojisteni.Models.Insureds;
using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.Account
{
    public class Register : Insureds.InsuredBase
    {
        [Required(ErrorMessage = "Zadejte heslo")]
        [StringLength(100, ErrorMessage = "Heslo musí být dlouhé alespoň 8 znaků", MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Zadejte heslo")]
        [Compare("Password", ErrorMessage = "Zopakujte správně heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Potvrzení hesla")]
        public string ConfirmPassword { get; set; }
    }
}
