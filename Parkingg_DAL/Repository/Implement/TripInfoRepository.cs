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
    public class TripInfoRepository : ITripInfoRepository
    {
        private readonly MyDbContext _context;
        public TripInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        // Add Trip
        public async Task AddTrip(Trip_Entities trip_Entities)
        {
            _context.trip_Entities.Add(trip_Entities);
        }
        // Delete Trip
        public async Task DeleteTripID(int IDTrip)
        {
            // Trả về một Object Entities
            var _deleteTrip = await _context.trip_Entities.FirstOrDefaultAsync(p => p.TripId == IDTrip);
            if (_deleteTrip != null)
            {
                _context.trip_Entities.Remove(_deleteTrip);
            }
        }
        // Find with ID on Trip
        public async Task<Trip_Entities?> FindIDTrip_Entities(int IDTrip)
        {
            var _findTrip = await _context.trip_Entities.Include(x => x.ListTicket).FirstOrDefaultAsync(p => p.TripId == IDTrip);
            return _findTrip;
        }
        // Từ Trip suy ra ID
        public async Task<Trip_Entities> FindTripWithID_Entities(string trip)
        {
            // Từ Destination trả về một Trip_Entities
            var _tripEntites = await _context.trip_Entities.Include(x => x.ListTicket).Include(x => x.ListBookingOffice).FirstOrDefaultAsync(p => p.Destination == trip);
            return _tripEntites;
        }
        // Get Trip (Show)
        public async Task<IEnumerable<Trip_Entities>> GetTrip_Entities()
        {
            return await _context.trip_Entities.ToListAsync();
        }
        // PageNumber là số trang hiện tại ( vd: 2/10), pageSize là độ dài của một trang
        public async Task<IEnumerable<Trip_Entities>> GetTripPage_Entities(int pageNumber, int pageSize)
        {
            return await _context.trip_Entities.OrderBy(c => c.Destination).
                Skip(pageSize * (pageNumber - 1)).
                Take(pageSize).ToListAsync();
        }
        // Tìm kiếm string nào đó trong database và lọc theo Name
        public async Task<IEnumerable<Trip_Entities>> GetTripNameAndSearch_Entities(string Destination, string search)
        {
            if (string.IsNullOrEmpty(Destination) && string.IsNullOrWhiteSpace(search))
            {
                return await GetTrip_Entities();
            }
            // collection to start from
            var collection = _context.trip_Entities as IQueryable<Trip_Entities>;
            if (!string.IsNullOrWhiteSpace(Destination))
            {
                Destination = Destination.Trim();
                collection = collection.Where(c => c.Destination == Destination);
            }
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                collection = collection.Where(a => a.Destination.Contains(search)
                    || (a.CarType != null && a.CarType.Contains(search)));
            }
            return await collection.OrderBy(c => c.Destination).ToListAsync();
        }
    }
}
