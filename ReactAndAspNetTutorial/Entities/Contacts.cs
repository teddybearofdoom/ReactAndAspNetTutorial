using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAndAspNetTutorial.Entities
{
    [Table("contacts")]
    public class Contacts
    {
        [Key]
        public Guid ContactId { get; set; }
        [Key]
        [Required(ErrorMessage = "First Name is required")]
        public string FirstName { get; set; } = string.Empty;
        [Key]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; } = string.Empty;
        public string ConjoiningName { get; set; } = string.Empty;
        [Key]
        [Required(ErrorMessage = "Phone Number is required")]
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        [Key]
        [Required(ErrorMessage = "Address is required")]
        public Address Address { get; set; } = new Address(); 
        
    }

    public class Address
    {
        public string HouseNo { get; set; } = string.Empty;
        public string StreetNo { get; set; } = string.Empty;
        public string Area { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string Region { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
    }
}
