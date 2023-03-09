using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ReactAndAspNetTutorial.Entities
{
    [Table("departments")]
    public class Departments
    {
        [Key]
        public Guid DeptId { get; set; }
        [Required(ErrorMessage = "Dept Name is required")]
        [StringLength(50)]
        public string DeptName { get; set; } = string.Empty;
    }
}
