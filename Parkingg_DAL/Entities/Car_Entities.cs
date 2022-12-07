using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class Car_Entities
    {
        // Data Car_Entities
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string CarType { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        public string CarColor { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string Company { get; set; } = string.Empty;
        [ForeignKey("ParkId")]
        public ParkingLot_Entities? parkingLot_Entities { get; set; }
        [Required]
        public int ParkId { get; set; }
        [Required]
        public List<Ticket_Entities> ListTicket { get; set; } = new List<Ticket_Entities>();
    }
}
