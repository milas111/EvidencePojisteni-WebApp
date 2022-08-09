using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.Insurances
{
    public class InsuranceView
    {
        public int InsuranceId { get; set; }

        [Required(ErrorMessage = "Zadejte název pojištění")]
        [Display(Name = "Název pojištění")]
        public string InsuranceName { get; set; }

        [Required(ErrorMessage = "Zadejte popis pojištění")]
        [Display(Name = "Popis pojištění")]
        public string InsuranceDescription { get; set; }

        [Required(ErrorMessage ="Vložte obrázek k pojištění")]
        [Display(Name = "Obrázek k pojištění")]
        public IFormFile InsuranceImage { get; set; }

        public string ExistingImage { get; set; }
    }
}
