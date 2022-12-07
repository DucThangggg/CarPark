using AutoMapper;
using Parking_DAL.DbContexts;
using Parking_DAL.Entities;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.AutoMap
{
    public class TripProfile : Profile
    {
        public TripProfile()
        {
            // Tạo ánh xạ Mapper
            CreateMap<Trip_Entities, Trip_DTO>();
            CreateMap<Trip_DTO, Trip_Entities>();
            CreateMap<Trip_Entities, TripList>();
            CreateMap<TripList, Trip_Entities>();
        }
    }
}
