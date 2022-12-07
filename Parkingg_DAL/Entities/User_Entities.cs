using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class User_Entities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int UserId { get; set; }
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty ;
        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string Role { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string FirstName { get; set; } = string.Empty ;
        [Required]
        [MaxLength(20)]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public int Phone { get; set; }
        [Required]
        [MaxLength(50)]
        public string Address { get; set; } = string.Empty;
    }
}
