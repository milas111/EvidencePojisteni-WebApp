using EvidencePojisteni.Models.Insureds;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EvidencePojisteni.Models.AssignedInsurances
{
    public class AssignedInsurancesToPolicyholders
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int Id { get; set; }

        [ForeignKey("AssignedInsurance")]
        [Display(Name = "Přiřazené pojištění")]
        public int AssignedInsuranceId { get; set; }

        [ForeignKey("Insured")]
        public int? InsuredId { get; set; }

        [Display(Name ="Přiřazené pojištění")]
        public virtual AssignedInsurance AssignedInsurance { get; set; }

        [Display(Name = "Pojistník")]
        public virtual Insured Insured { get; set; }
    }
}
