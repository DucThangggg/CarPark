using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DTO
{
    public class ParkingLotList
    {
        // Data ParkingLotList
        [Required]
        public int ParkId { get; set; }
        [Required]
        [MaxLength(50)]
        public string ParkName { get; set; } = string.Empty;
        [Required]
        [MaxLength(11)]
        public string ParkPlace { get; set; } = string.Empty;
        [Required]
        [MaxLength(20)]
        public string ParkArea { get; set; } = string.Empty;
        [Required]
        public int ParkPrice { get; set; }
        [Required]
        [MaxLength(50)]
        public string ParkStatus { get; set; } = string.Empty;
    }
}
