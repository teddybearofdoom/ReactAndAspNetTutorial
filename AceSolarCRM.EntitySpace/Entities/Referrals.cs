using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.EntitySpace.Entities
{ 
    [Table("Referrals")]
    public class Referrals
    {
        [Key]
        public Guid ReferralId { get; set; } = Guid.NewGuid();
        
        [Required(ErrorMessage = "Referral Name is required e.g. Advertisement in NewsPaper - Jung")]
        [StringLength(50)]
        public string ReferralName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Referral Descript is required e.g. the link to the advertisement")]
        public string ReferralDesc { get; set; } = string.Empty;

    }
}
