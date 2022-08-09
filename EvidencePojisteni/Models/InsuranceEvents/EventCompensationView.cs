using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.InsuranceEvents
{
    public class EventCompensationView
    {
        [Required(ErrorMessage = "Vyplňte také číslo účtu")]
        [StringLength(20, ErrorMessage = "Číslo účtu je příliš dlouhé, max. 20 znaků")]
        [Display(Name = "Číslo účtu")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Vyplňte také kód banky")]
        [Display(Name = "Kód banky")]
        public string BankCode { get; set; }
    }
}
