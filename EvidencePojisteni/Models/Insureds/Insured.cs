using EvidencePojisteni.Models.AssignedInsurances;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using X.PagedList;

namespace EvidencePojisteni.Models.Insureds
{
    public class Insured : InsuredBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity), Key()]
        public int InsuredId { get; set; }

        [ForeignKey("User")]
        public string UserId { get; set; }

        public virtual ICollection<AssignedInsurance> AssignedInsurances { get; set; }

        public virtual ICollection<AssignedInsurancesToPolicyholders> AssignedInsurancesToPolicyholders { get; set; }

        public virtual IdentityUser User { get; set; }
    }
}
