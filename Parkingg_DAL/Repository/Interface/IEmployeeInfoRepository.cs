using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public interface IEmployeeInfoRepository
    {
        // Show Employee (Get)
        Task<IEnumerable<Employee_Entities>> GetEmployee_Entities();
        // Show EmployeePage (Get)
        Task<IEnumerable<Employee_Entities>> GetEmployeePage_Entities(int pageNumber, int pageSize);
        // Thêm Employee (Post)
        Task AddEmployee(Employee_Entities employee_Entities);
        // Tìm theo ID
        Task<Employee_Entities?> FindIDEmployee_Entities(int IDEmployee);
        // Sửa thì dùng ánh xạ (Mapper DTO và Entities)
        // Xóa theo ID
        Task DeleteEmployeeID(int IDEmployee);
        // Lọc theo tên và Search theo string
        Task<IEnumerable<Employee_Entities>> GetEmployeeNameAndSearch_Entities(string employeeName, string search);
    }
}
