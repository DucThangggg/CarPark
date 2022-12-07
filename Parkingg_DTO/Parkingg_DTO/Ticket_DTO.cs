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
    public class Ticket_DTO
    {
        // Data Ticket_DTO
        [Required]
        [MaxLength(11)]
        public string CustomerName { get; set; } = string.Empty;
        [Required]
        public TimeOnly BookingTime { get; set; }
        [Required]
        [MaxLength(50)]
        public string Destination { get; set; } = string.Empty;
        [Required]
        [MaxLength(50)]
        public string LicensePlate { get; set; } = string.Empty;
        // Id thêm vào sử dụng cho TicketBLL chứ không điền khi Add, thì Trip sẽ tìm ra được ID để hiển thị
        [Required]
        public int TripId { get; set; }
    }
}
