using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public interface IEmployeeBLL
    {
        // Get (Show)
        Task<IEnumerable<Employee_DTO>> GetEmployee_Map();
        // Get (Show)
        Task<IEnumerable<Employee_DTO>> GetEmployeePage_Map(int pageNumber, int pageSize);
        // Post theo ID
        Task<Employee_DTO> PostEmployee_Map(Employee_DTO employee_Post);
        // Update theo ID
        Task<Employee_DTO> UpdateEmployeeID_Map(int IDEmployee, Employee_DTO employee_Update);
        // Delete theo ID
        Task<bool> DeleteEmployeeID(int IDEmployee);
        // Get theo Filter and Search
        Task<IEnumerable<Employee_DTO>> GetEmployeeNameAndSearch_Map(string employeeName, string search);
    }
}
