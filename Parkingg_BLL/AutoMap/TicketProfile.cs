using AutoMapper;
using Parking_DAL.Entities;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.AutoMap
{
    public class TicketProfile : Profile
    {
        public TicketProfile()
        {
            // Tạo ánh xạ Mapper
            CreateMap<Ticket_Entities, TicketList>().ForMember(destination => destination.Destination,
                           options => options.MapFrom(source => source.trip_Entities.Destination)); // Hiển thị Destination từ Map Entiites vs List
            CreateMap<Ticket_DTO, Ticket_Entities>();
            CreateMap<TicketList, Ticket_Entities>();
            CreateMap<Ticket_Entities, Ticket_DTO>();
        }
    }
}
