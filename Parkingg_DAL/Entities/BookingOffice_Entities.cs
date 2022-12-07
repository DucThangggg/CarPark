using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class BookingOffice_Entities
    {
        // Data BookingOffice_Entities
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Required]
        public int OfficeId { get; set; }
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
        [ForeignKey("TripId")]
        public Trip_Entities? trip_Entities { get; set; }
        [Required]
        public int TripId { get; set; }
    }
}
