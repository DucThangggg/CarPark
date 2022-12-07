using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public interface ITicketBLL
    {
        // Get (Show)
        Task<IEnumerable<TicketList>> GetTicketList_Map();
        // Post Ticket
        Task<Ticket_DTO> PostTicket_Map(Ticket_DTO ticket_Post);
        // Update Ticket
        Task<Ticket_DTO> UpdateTicketID_Map(int IDTicket, Ticket_DTO ticket_Update);
        // Delete theo ID
        Task<bool> DeleteTicketID(int IDTicket);
    }
}
