using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DTO
{
    public class TicketList
    {
        [Required]
        public int TicketId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Destination { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public TimeOnly BookingTime { get; set; }
        [Required]
        public int TripId { get; set; }
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;
    }
}
