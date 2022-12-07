using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public interface IBookingOfficeBLL
    {
        // Get (Show)
        Task<IEnumerable<BookingOfficeList>> GetBookingOfficeList_Map();
        // Post booking
        Task<BookingOffice_DTO> PostBookingOffice_Map(BookingOffice_DTO booking_Post);
        // Update BookingOffice
        Task<BookingOffice_DTO> UpdateBookingOfficeID_Map(int IDBooking, BookingOffice_DTO booking_Update);
        // Delete theo ID
        Task<bool> DeleteBookingOfficeID(int IDBookingOffice);
    }
}
