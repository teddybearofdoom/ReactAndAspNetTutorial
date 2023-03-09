using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAndAspNetTutorial.Entities
{
    [Table("vendors")]
    public class Vendors
    {
        [Key]
        public Guid VendorId { get; set; }
        
        [ForeignKey(nameof(Contacts))]
        public Guid ContactId { get; set; }
        
        [ForeignKey(nameof(Companies))]
        public Guid CompanyId { get; set; }
        
        public Contacts VendorContactDetails { get; set; } = new Contacts();
        public Companies VendorCompanyDetails { get; set; } = new Companies(); 
    }
}
