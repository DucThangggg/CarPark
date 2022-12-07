using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DTO
{
    public class User_DTO
    {
        [Required]
        [MaxLength(20)]
        public string UserName { get; set; } = string.Empty;
        [Required]
        [MaxLength(30)]
        public string Password { get; set; } = string.Empty;
    }
}