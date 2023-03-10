using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceSolarCRM.EntitySpace.Entities
{
    [Table("Companies")]
    public class Deals
    {
        [Key]
        public Guid DealsId { get; set; }
        
        [Required(ErrorMessage = "Proposal is required")]
        public byte[]? Proposal { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        [ForeignKey(nameof(Employees))]
        public Guid FocalPerson { get; set; }
        public DateTime PrimaryVisit { get; set; }
        public DateTime PrimaryMeeting { get; set; }
        public byte[]? PrimarySketch { get; set; }

        [ForeignKey(nameof(Contacts))]
        public Guid ContactId { get; set; }
        [ForeignKey(nameof(Contacts))]
        public string FirstName { get; set; } = string.Empty;
        [ForeignKey(nameof(Contacts))]
        public string LastName { get; set; } = string.Empty;
        [ForeignKey(nameof(Contacts))]
        public string PhoneNumber { get; set; } = string.Empty;
        
        public Contacts ContactLeadPerson { get; set; } = new();
        public Employees EmployeeFocalPerson { get; set; } = new();
    }
}
