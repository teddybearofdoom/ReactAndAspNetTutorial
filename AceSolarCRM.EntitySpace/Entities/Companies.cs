using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceSolarCRM.EntitySpace.Entities
{
    [Table("Companies")]
    public class Companies
    {
        [Key]
        public Guid CompanyId { get; set; }
        
        [Required(ErrorMessage = "Company Name is required")]
        [StringLength(100)]
        public string CompanyName { get; set; } = string.Empty;
        
        [Required(ErrorMessage = "Company Address is required")]
        public Address Address { get; set; } = new();

        [Required]
        public string Phone { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        

    }
}
