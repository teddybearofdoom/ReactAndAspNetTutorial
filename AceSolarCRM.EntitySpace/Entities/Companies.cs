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
        
        [Required(ErrorMessage = "HouseNo is required")]
        [StringLength(15)]
        public string HouseNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "StreetNo is required")]
        [StringLength(30)]
        public string StreetNo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Area is required")]
        [StringLength(30)]
        public string Area { get; set; } = string.Empty;

        [Required(ErrorMessage = "City is required")]
        [StringLength(30)]
        public string City { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "Region is required")]
        [StringLength(30)]
        public string Region { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "PostalCode is required")]
        [StringLength(15)]
        public string PostalCode { get; set; } = string.Empty;

        
        [Required(ErrorMessage = "Country is required")]
        [StringLength(25)]
        public string Country { get; set; } = string.Empty;

        [Required]
        public string Phone { get; set; } = string.Empty;
        public string Website { get; set; } = string.Empty;
        

    }
}
