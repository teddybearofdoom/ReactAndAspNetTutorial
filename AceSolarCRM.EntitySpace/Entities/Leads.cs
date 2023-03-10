using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceSolarCRM.EntitySpace.Entities
{
    [Table("Leads")]
    public class Leads
    {
        public Guid LeadId { get; set; }

        [Required(ErrorMessage = "Lead Name is required")]
        [StringLength(60, ErrorMessage = "Lead can't be longer than 60 characters")]
        public string? LeadName { get; set; }

        [Required(ErrorMessage = "Referral Type is required")]
        public string ReferralType { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Referred By is required")]
        public string ReferredBy { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        [StringLength(100)]
        public string Address { get; set; } = string.Empty;
        
        public byte[]? Proposal { get; set; }
        [ForeignKey("EmployeeId")]
        public Guid AssignedTo { get; set; }
        public DateTime AddedOn { get; set; } = DateTime.Now;
        public Employees? EmployeeAssigned { get; set; }
    }

    public enum Lead_ReferralType
    {
        WordOfMouth,
        Advertisements,
        Other
    }
}
