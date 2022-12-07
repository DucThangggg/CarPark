using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DTO
{
    public class TripList
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
        public int BookedTicketNumber { get; set; }
        [Required]
        public TimeOnly DepartureTime { get; set; }
    }
}
