using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceSolarCRM.EntitySpace.Entities
{
    [Table("Contacts")]
    public class Contacts
    {
        [Key]
        public Guid ContactId { get; set; }
        
        [Key]
        [Required(ErrorMessage = "First Name is required")]
        [StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        
        [Key]
        [Required(ErrorMessage = "Last Name is required")]
        [StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        
        [StringLength(10)]
        public string? ConjoiningName { get; set; }
        
        [Key]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = string.Empty;
        
        public string Email { get; set; } = string.Empty;
        
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

    }
}
