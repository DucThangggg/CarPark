using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking_BLL.Service;
using Parking_DAL.DbContexts;
using Parking_DTO;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class BookingOfficeController : ControllerBase
    {
        public IBookingOfficeBLL _bookingBll;
        // Hàm khởi tạo
        public BookingOfficeController(IBookingOfficeBLL bookingBll)
        {
            _bookingBll = bookingBll ??
                throw new ArgumentNullException(nameof(bookingBll));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<BookingOfficeList>>> GetBookingOfficeList_Map()
        {
            return Ok(await _bookingBll.GetBookingOfficeList_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<BookingOffice_DTO>>> PostBookingOffice_Map(BookingOffice_DTO booking_Post)
        {
            return Ok(await _bookingBll.PostBookingOffice_Map(booking_Post));
        }
        [HttpPut("UpdateBookingOffice/{IDBooking}")]
        public async Task<ActionResult<IEnumerable<BookingOffice_DTO>>> UpdateBookingOfficeID_Map(int IDBooking, BookingOffice_DTO booking_Update)
        {
            return Ok(await _bookingBll.UpdateBookingOfficeID_Map(IDBooking, booking_Update));
        }
        [HttpDelete("DeleteBookingOffice/{IDBookingOffice}")]
        public async Task<ActionResult<bool>> DeleteBookingOfficeID(int IDBookingOffice)
        {
            return Ok(await _bookingBll.DeleteBookingOfficeID(IDBookingOffice));
        }
    }
}
