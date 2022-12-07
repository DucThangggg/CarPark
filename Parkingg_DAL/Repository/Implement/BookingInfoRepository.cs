using Microsoft.EntityFrameworkCore;
using Parking_DAL.DbContexts;
using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public class BookingInfoRepository : IBookingOfficeInfoRepository
    {
        private readonly MyDbContext _context;
        public BookingInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Add Trip
        public async Task AddBooking(BookingOffice_Entities booking_Entities, Trip_Entities trip_Entities)
        {
            trip_Entities.ListBookingOffice.Add(booking_Entities);
        }
        public async Task<IEnumerable<BookingOffice_Entities>> GetBookingOfficeList_Entities()
        {
            // Get Booking ( một List)
            return await _context.bookingOffice_Entities.Include(x => x.trip_Entities).ToListAsync();
        }
        // Find with ID on Booking
        public async Task<BookingOffice_Entities?> FindIDBookingOffice_Entities(int IDBookingOffice)
        {
            var _findbooking = await _context.bookingOffice_Entities.FirstOrDefaultAsync(p => p.OfficeId == IDBookingOffice);
            return _findbooking;
        }
        // Delete BookingOffice
        public async Task DeleteBookingOfficeID(int IDBookingOffice)
        {
            // Trả về một Object Entities
            var _deleteBooking = await _context.bookingOffice_Entities.FirstOrDefaultAsync(p => p.OfficeId == IDBookingOffice);
            if (_deleteBooking != null)
            {
                _context.bookingOffice_Entities.Remove(_deleteBooking);
            }
        }
    }
}
