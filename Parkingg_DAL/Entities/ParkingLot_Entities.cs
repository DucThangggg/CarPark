using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Entities
{
    public class ParkingLot_Entities
    {
        // Data ParkingLot_Entities
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
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
        [Required]
        public List<Car_Entities> ListCar { get; set; } = new List<Car_Entities>();
    }
}
