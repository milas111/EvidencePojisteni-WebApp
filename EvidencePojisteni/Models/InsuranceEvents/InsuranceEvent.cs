using EvidencePojisteni.Models.Insurances;
using EvidencePojisteni.Models.Insureds;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni.Models.InsuranceEvents
{
    public class InsuranceEvent : InsuredBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        [Display(Name = "Id")]
        public int InsuranceEventId { get; set; }

        [Required]
        [ForeignKey("Insurance")]
        [Display(Name = "Pojištění")]
        public int InsuranceId { get; set; }

        [Display(Name = "Pojištění k události")]
        public virtual Insurance Insurance { get; set; }

        [ForeignKey("Insured")]
        public int? InsuredId { get; set; }

        [Display(Name ="Pojištěnec")]
        public virtual Insured Insured { get; set; }

        [Required(ErrorMessage ="Zadejte datum")]
        [Display(Name ="Datum události")]
        [DataType(DataType.Date, ErrorMessage = "Zadané datum není validní")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage ="Vyplňte popis události")]
        [Display(Name ="Popis události")]
        public string EventDescription { get; set; }

        [Required(ErrorMessage = "Vyplňte také číslo účtu")]
        [StringLength(20, ErrorMessage = "Číslo účtu je příliš dlouhé, max. 20 znaků")]
        [Display(Name = "Číslo účtu")]
        public string AccountNumber { get; set; }

        [Required(ErrorMessage = "Vyplňte také kód banky")]
        [Display(Name = "Kód banky")]
        public string BankCode { get; set; }
    }
}
