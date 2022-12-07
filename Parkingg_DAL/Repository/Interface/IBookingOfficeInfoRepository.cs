using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public interface IBookingOfficeInfoRepository
    {
        // Trả về danh sách BookingOfficeList include Trip (Địa điểm )
        Task<IEnumerable<BookingOffice_Entities>> GetBookingOfficeList_Entities();
        // Thêm Booking (Post)
        Task AddBooking(BookingOffice_Entities booking_Entities, Trip_Entities trip_Entities);
        // Tìm theo ID trả về một hàng thông tin
        Task<BookingOffice_Entities?> FindIDBookingOffice_Entities(int IDBookingOffice);
        // Xóa theo ID
        Task DeleteBookingOfficeID(int IDBookingOffice);
    }
}
