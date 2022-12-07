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
    public class ParkingLotProfile : Profile
    {
        public ParkingLotProfile()
        {
            // Tạo ánh xạ Mapper
            CreateMap<ParkingLot_Entities, ParkingLotList>();
            CreateMap<ParkingLot_DTO, ParkingLot_Entities>();
            CreateMap<ParkingLotList, ParkingLot_Entities>();
            CreateMap<ParkingLot_Entities, ParkingLot_DTO>();
        }
    }
}
