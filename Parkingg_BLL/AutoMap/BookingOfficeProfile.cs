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
    public class BookingOfficeProfile : Profile
    {
        public BookingOfficeProfile()
        {
            // Tạo ánh xạ Mapper
            CreateMap<BookingOffice_Entities, BookingOfficeList>().ForMember(destination => destination.Destination,
                           options => options.MapFrom(source => source.trip_Entities.Destination)); // Hiển thị Destination từ Map Entiites vs List
            CreateMap<BookingOffice_DTO, BookingOffice_Entities>();
            CreateMap<BookingOfficeList, BookingOffice_Entities>();
            CreateMap<BookingOffice_Entities, BookingOffice_DTO>();
        }
    }
}
