using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AceSolarCRM.EntitySpace.Entities
{
    [Table("Employees")]
    public class Employees
    {
        [Key]
        public Guid EmpId { get; set; }
        
        [ForeignKey(nameof(Contacts))]
        public Guid ContactId { get; set; }

        public DateTime JoiningDate { get; set; }
        public string JobTitle { get; set; } = string.Empty;
        [ForeignKey(nameof(Departments))]
        public Guid DeptId { get; set; }
        public double Salary { get; set; }
        public Contacts EmpContactDetails { get; set; } = new Contacts();
        public Departments EmpDepartment { get; set; } = new Departments();
    }
}
