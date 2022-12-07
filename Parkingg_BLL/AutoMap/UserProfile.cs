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
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User_Entities, User_DTO>();
            CreateMap<User_DTO, User_Entities>();
        }
    }
}
