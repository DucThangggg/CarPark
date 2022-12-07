using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking_BLL.Service;
using Parking_DTO;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class TicketController : ControllerBase
    {
        public ITicketBLL _ticketBll;
        // Hàm khởi tạo
        public TicketController(ITicketBLL ticketBll)
        {
            _ticketBll = ticketBll ??
                throw new ArgumentNullException(nameof(ticketBll));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TicketList>>> GetTicketList_Map()
        {
            return Ok(await _ticketBll.GetTicketList_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Ticket_DTO>>> PostTicket_Map(Ticket_DTO ticket_Post)
        {
            return Ok(await _ticketBll.PostTicket_Map(ticket_Post));
        }
        [HttpPut("UpdateTicket/{IDTicket}")]
        public async Task<ActionResult<IEnumerable<BookingOffice_DTO>>> UpdateTicketID_Map(int IDTicket, Ticket_DTO ticket_Update)
        {
            return Ok(await _ticketBll.UpdateTicketID_Map(IDTicket, ticket_Update));
        }
        [HttpDelete("DeleteTicket/{ID}")]
        public async Task<ActionResult<bool>> DeleteTicketID(int IDTicket)
        {
            return Ok(await _ticketBll.DeleteTicketID(IDTicket));
        }
    }
}
