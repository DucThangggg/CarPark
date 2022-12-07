using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_DAL.DbContexts;

namespace Parking_DTO
{
    public class BookingOffice_DTO
    {
        // Data BookingOffice_DTO
        [Required]
        [MaxLength(50)]
        public string BookingOfficeName { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string OfficePhone { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string OfficePlace { get; set; } = string.Empty;
        [Required]
        public int OfficePrice { get; set; }
        [Required]
        public DateOnly StartContractDeadline { get; set; }
        [Required]
        public DateOnly EndContractDeadline { get; set; }
        [Required]
        [MaxLength(50)]
        public string Destination { get; set; } = string.Empty;
        [Required]
        public int TripId { get; set; }
    }
}
