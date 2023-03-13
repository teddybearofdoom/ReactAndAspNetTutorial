using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AceSolarCRM.EntitySpace.Entities
{
    [Table("Admin")]
    public class Admin
    {
        public string UserName { get; set; } = string.Empty;
        [Key]
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
    }
}
