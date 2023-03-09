using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAndAspNetTutorial.Entities
{
    public class Customers
    {
        [Key]
        public Guid CustId { get; set; }
        [ForeignKey(nameof(Contacts))]
        public Guid ContactId { get; set; }
        public string CustomerType { get; set; } = string.Empty;

        [ForeignKey(nameof(Employees))]
        public Guid FocalPerson { get; set; }
        public string LocationPin { get; set; } = string.Empty;
        public Contacts CustomerContactDetails { get; set; } = new Contacts();
        public Employees FocalPersonDetails { get; set; } = new Employees();
    }

    public enum CustomerType
    {
        HomeOwner,
        SchoolOwner,
        Business,
        PlantOwner,
        Other
    }
}
