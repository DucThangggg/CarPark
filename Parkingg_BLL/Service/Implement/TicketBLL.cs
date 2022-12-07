using AutoMapper;
using Parking_DAL.DbContexts;
using Parking_DAL.Entities;
using Parking_DAL.UnitOfWork;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public class TicketBLL : ITicketBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        // Hàm khởi tạo
        public TicketBLL(IParking_UnitOfWork parking, IMapper mapper)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> DeleteTicketID(int IDTicket)
        {
            // Tìm theo ID
            var _deleteTicket = await _parking.ticketInfoRepository.FindIDTicket_Entities(IDTicket);
            if (_deleteTicket == null)
            {
                return false;
            }
            await _parking.tripInfoRepository.DeleteTripID(IDTicket);
            await _parking.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<TicketList>> GetTicketList_Map()
        {
            // Gọi hàm thông qua Unit và Object TicketInfoRepository khai báo ở IParkingUnitOfWork
            var ticket_Entities = await _parking.ticketInfoRepository.GetTicketList_Entities();
            return _mapper.Map<IEnumerable<TicketList>>(ticket_Entities);
        }
        public async Task<Ticket_DTO> PostTicket_Map(Ticket_DTO ticket_Post)
        {
            // ticket_Post là Object Ticket_DTO được thêm vào, chấm Destination là gọi biến trong Object Booking đó
            var ticketEntities1 = await _parking.tripInfoRepository.FindTripWithID_Entities(ticket_Post.Destination);
            var ticketEntities2 = await _parking.carInfoRepository.FindCarWithLicense_Entities(ticket_Post.LicensePlate);
            // Từ Id thêm vào thì tìm ra ID của ticketEntities, ban đầu ticket_Post không có Id, bên phải là thêm ID vào bên trái để Mapper
            //ticket_Post.TripId = ticketEntities1.TripId;
            //ticket_Post.LicensePlate = ticketEntities2.LicensePlate;
            var ticketPost = _mapper.Map<Ticket_Entities>(ticket_Post);
            await _parking.ticketInfoRepository.AddTicket(ticketPost, ticketEntities1, ticketEntities2);
            // Lưu giá trị vào Database
            await _parking.SaveChanges();
            return _mapper.Map<Ticket_DTO>(ticketPost);
        }
        public async Task<Ticket_DTO> UpdateTicketID_Map(int IDTicket, Ticket_DTO ticket_Update)
        {
            // Tìm theo ID
            var ticket_Entities = await _parking.ticketInfoRepository.FindIDTicket_Entities(IDTicket);
            // Ánh xạ hai giá trị để thực hiện Insert
            _mapper.Map(ticket_Update, ticket_Entities);
            // Lưu vào giá trị là Entities
            await _parking.SaveChanges();
            return _mapper.Map<Ticket_DTO>(ticket_Entities);
        }
    }
}
