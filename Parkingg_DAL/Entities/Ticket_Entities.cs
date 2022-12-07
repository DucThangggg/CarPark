using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class Ticket_Entities
    {
        // Data Ticket_Entities
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TicketId { get; set; }
        [Required]
        [MaxLength(11)]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public TimeOnly BookingTime { get; set; }
        [ForeignKey("TripId")]
        public Trip_Entities? trip_Entities { get; set; } // Lấy sang hàm chứa include
        [Required]
        public int TripId { get; set; }
        [ForeignKey("LicensePlate")]
        public Car_Entities? Car_Entities { get; set; }   // Lấy sang hàm chứa include
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;
    }
}
