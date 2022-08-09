using System;
using System.ComponentModel.DataAnnotations;

namespace EvidencePojisteni.Models.InsuranceEvents
{
    public class EventDetailsView
    {
        [Required(ErrorMessage = "Zadejte datum")]
        [Display(Name = "Datum události")]
        [DataType(DataType.Date, ErrorMessage = "Zadané datum není validní")]
        public DateTime EventDate { get; set; }

        [Required(ErrorMessage = "Vyplňte popis události")]
        [Display(Name = "Popis události")]
        public string EventDescription { get; set; }
    }
}
