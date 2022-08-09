using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.InsuranceEvents
{
    public class EventInsuranceView
    {
        [Required]
        [Display(Name = "Pojištění")]
        public int InsuranceId { get; set; }

        public int? InsuredId { get; set; }
    }
}
