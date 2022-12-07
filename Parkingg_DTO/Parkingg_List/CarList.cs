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
    public class CarList
    {
        // Data CarList
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
        [Required]
        [MaxLength(50)]
        public string ParkName { get; set; } = string.Empty;
    }
}
