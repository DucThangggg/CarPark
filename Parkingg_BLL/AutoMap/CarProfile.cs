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
    public class CarProfile : Profile
    {
        public CarProfile()
        {
            // Tạo ánh xạ Mapper
            CreateMap<Car_Entities, CarList>().ForMember(destination => destination.ParkName,
                           options => options.MapFrom(source => source.parkingLot_Entities.ParkName)); // Hiển thị Destination từ Map Entiites vs List
            CreateMap<Car_DTO, Car_Entities>();
            CreateMap<CarList, Car_Entities>();
            CreateMap<Car_Entities, Car_DTO>();
        }
    }
}
