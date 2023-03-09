using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAndAspNetTutorial.Entities
{
    [Table("leads")]
    public class Leads
    {
        public Guid LeadId { get; set; }

        [Required(ErrorMessage = "Contact Name is required")]
        [StringLength(60, ErrorMessage = "Name can't be longer than 60 characters")]
        public string? ContactName { get; set; }

        [Required(ErrorMessage = "Referral Type is required")]
        public string ReferralType { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Referred By is required")]
        public string ReferredBy { get; set; } = string.Empty;

        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; } = new Address(); 

        public byte[]? Proposal { get; set; }
        [ForeignKey("EmployeeId")]
        public Guid AssignedTo { get; set; }
        public Employees? EmployeeAssigned { get; set; }
    }

    public enum Lead_ReferralType
    {
        WordOfMouth,
        Advertisements,
        Other
    }
}
