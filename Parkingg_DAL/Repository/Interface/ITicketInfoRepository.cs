using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public interface ITicketInfoRepository
    {
        // Trả về danh sách TicketList include Trip (Địa điểm )
        Task<IEnumerable<Ticket_Entities>> GetTicketList_Entities();
        // Thêm Ticket (Post)
        Task AddTicket(Ticket_Entities ticket_Entities, Trip_Entities trip_Entities, Car_Entities car_Entities);
        // Tìm theo ID
        Task<Ticket_Entities?> FindIDTicket_Entities(int IDTicket);
        // Sửa thì dùng ánh xạ (Mapper DTO và Entities)
        // Xóa theo ID
        Task DeleteTicketID(int IDTicket);
    }
}
