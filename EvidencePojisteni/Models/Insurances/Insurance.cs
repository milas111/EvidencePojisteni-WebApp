using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace EvidencePojisteni.Models.Insurances
{
    public class Insurance
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int InsuranceId { get; set; }

        [Required(ErrorMessage = "Zadejte název pojištění")]
        [StringLength(20, ErrorMessage = "Zadejte název v délce 4 až 20 znaků", MinimumLength = 4)]
        [Display(Name = "Název pojištění")]
        public string InsuranceName { get; set; }

        [Required(ErrorMessage = "Zadejte popis pojištění")]
        [StringLength(2000, ErrorMessage = "Popis pojištění nesmí překročit 2000 znaků")]
        [Display(Name = "Popis pojištění")]
        public string InsuranceDescription { get; set; }

        [Required]
        [Display(Name = "Obrázek k pojištění")]
        public string InsuranceImage { get; set; }
    }
}
