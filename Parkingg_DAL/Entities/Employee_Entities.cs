using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class Employee_Entities
    {
        // Data Employee
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int EmployeeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string EmployeeName { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string EmployeePhone { get; set; } = string.Empty;
        [Required]
        public DateOnly EmployeeBrithday { get; set; }
        [Required]
        [MaxLength(10)]
        public string Sex { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string EmployeeAddress { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string EmployeeEmail { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Account { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(10)]
        public string Department { get; set; } = string.Empty;
    }
}
