using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;
using Parking_DAL.DbContexts;
using System.Text.Json;

namespace Parking_DAL.DbContexts
{
    public class Trip_DTO
    {
        // Trip_DTO dùng để Add Trip, TripList dùng để hiển thị
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
        [JsonConverter(typeof(TimeOnlyJsonConverter))]
        [Required]
        public TimeOnly DepartureTime { get; set; }
        [JsonConverter(typeof(DateOnlyJsonConverter))]
        [Required]
        public DateOnly DepartureDate { get; set; }

    }
}
