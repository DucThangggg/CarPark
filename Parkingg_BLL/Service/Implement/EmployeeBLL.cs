using AutoMapper;
using Parking_DAL.Entities;
using Parking_DAL.UnitOfWork;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_DAL.DbContexts;
using Microsoft.EntityFrameworkCore;

namespace Parking_BLL.Service
{
    public class EmployeeBLL : IEmployeeBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        // Hàm khởi tạo
        public EmployeeBLL(IParking_UnitOfWork parking, IMapper mapper)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        // Thực hiện await với các I/O, thực hiện hàm hoặc lưu vào CSDL, không dùng khi thực hiện ánh xạ
        public async Task<bool> DeleteEmployeeID(int IDEmployee)
        {
            // Tìm theo ID
            var _deleteEmployee = await _parking.employeeInfoRepository.FindIDEmployee_Entities(IDEmployee);
            if (_deleteEmployee == null)
            {
                return false;
            }
            await _parking.employeeInfoRepository.DeleteEmployeeID(IDEmployee);
            await _parking.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<Employee_DTO>> GetEmployeePage_Map(int pageNumber, int pageSize)
        {
            // Gọi hàm thông qua Unit và Object EmployeeInfoRepository khai báo ở IParkingUnitOfWork
            var employee_Entities = await _parking.employeeInfoRepository.GetEmployeePage_Entities(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<Employee_DTO>>(employee_Entities);
        }
        // Get theo Filter and Search
        public async Task<IEnumerable<Employee_DTO>> GetEmployeeNameAndSearch_Map(string employeeName, string search)
        {
            // Gọi hàm thông qua Unit và Object EmployeeInfoRepository khai báo ở IParkingUnitOfWork
            var employee_Entities = await _parking.employeeInfoRepository.GetEmployeeNameAndSearch_Entities(employeeName, search);
            return _mapper.Map<IEnumerable<Employee_DTO>>(employee_Entities);
        }
        public async Task<Employee_DTO> PostEmployee_Map(Employee_DTO employee_Post)
        {
            var employee_post = _mapper.Map<Employee_Entities>(employee_Post);
            await _parking.employeeInfoRepository.AddEmployee(employee_post);
            // Lưu giá trị vào Database
             await _parking.SaveChanges();
            return _mapper.Map<Employee_DTO>(employee_post);
        }
        // Get all
        public async Task<IEnumerable<Employee_DTO>> GetEmployee_Map()
        {
            // Gọi hàm thông qua Unit và Object EmployeeInfoRepository khai báo ở IParkingUnitOfWork
            var employee_Entities = await _parking.employeeInfoRepository.GetEmployee_Entities();
            return _mapper.Map<IEnumerable<Employee_DTO>>(employee_Entities);
        }
        public async Task<Employee_DTO> UpdateEmployeeID_Map(int IDEmployee, Employee_DTO employee_Update)
        {
            // Tìm theo ID
            var employee_Entities = await _parking.employeeInfoRepository.FindIDEmployee_Entities(IDEmployee);
            // Ánh xạ hai giá trị để thực hiện Insert
            _mapper.Map(employee_Update, employee_Entities);
            // Lưu vào giá trị là Entities
            await _parking.SaveChanges();
            return _mapper.Map<Employee_DTO>(employee_Entities);
        }
    }
}
