using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class Trip_Entities
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int TripId { get; set; }
        [Required]
        [MaxLength(50)]
        public string Destination { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        public string Driver { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        public string CarType { get; set; } = string.Empty;
        [Required]
        public int MaximumOnlineTicketNumber { get; set; }
        [Required]
        public int BookedTicketNumber { get; set; }
        [Required]
        public TimeOnly DepartureTime { get; set; }
        [Required]
        public DateOnly DepartureDate { get; set; }
        [Required]
        public List<BookingOffice_Entities> ListBookingOffice { get; set; } = new List<BookingOffice_Entities>();
        [Required]
        public List<Ticket_Entities> ListTicket { get; set; } = new List<Ticket_Entities>();
    }
}
