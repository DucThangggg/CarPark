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
    public class EmployeeProFile : Profile
    {
        public EmployeeProFile()
        {
            // Tạo ánh xạ Mapper
            CreateMap<Employee_Entities, Employee_DTO>();
            CreateMap<Employee_DTO, Employee_Entities>();
        }
    }
}
