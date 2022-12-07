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
    public class TicketInfoRepository : ITicketInfoRepository
    {
        private readonly MyDbContext _context;
        public TicketInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddTicket(Ticket_Entities ticket_Entities, Trip_Entities trip_Entities, Car_Entities car_Entities)
        {
            // Add Ticket vào Trip có thể là một List cùng TripID
            trip_Entities.ListTicket.Add(ticket_Entities);
            // Add Ticket vào Car có thể là một List cùng LicensePlate
            car_Entities.ListTicket.Add(ticket_Entities);
            // Kiểu int nên không cần Tostring() nữa
            trip_Entities.BookedTicketNumber = trip_Entities.ListTicket.Count;
        }
        public async Task DeleteTicketID(int IDTicket)
        {
            // Trả về một Object Entities
            var _deleteTicket = await _context.ticket_Entities.FirstOrDefaultAsync(p => p.TicketId == IDTicket);
            if (_deleteTicket != null)
            {
                _context.ticket_Entities.Remove(_deleteTicket);
            }
        }
        public async Task<Ticket_Entities?> FindIDTicket_Entities(int IDTicket)
        {
            // Trả về một Object (một hàng thông tin)
            return await _context.ticket_Entities.FirstOrDefaultAsync(p => p.TicketId == IDTicket);
        }
        public async Task<IEnumerable<Ticket_Entities>> GetTicketList_Entities()
        {
            // Get Ticket ( một List)
            return await _context.ticket_Entities.Include(x => x.trip_Entities).Include(x => x.Car_Entities).ToListAsync();
        }
    }
}
