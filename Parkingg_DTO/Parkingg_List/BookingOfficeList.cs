using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DTO
{
    public class BookingOfficeList
    {
        // Data BookingOfficeList
        [Required]
        public int OfficeId { get; set; }
        [Required]
        [MaxLength(50)]
        public string BookingOfficeName { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Destination { get; set; } = string.Empty;
    }
}
