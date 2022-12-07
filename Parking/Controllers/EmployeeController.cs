using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking_BLL.Service;
using Parking_DTO;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [Authorize(Roles = "Admin")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        public IEmployeeBLL _employeeBll;
        const int maxEmployeeSize = 20;
        // Hàm khởi tạo
        public EmployeeController(IEmployeeBLL employeeBll)
        {
            _employeeBll = employeeBll ??
                throw new ArgumentNullException(nameof(employeeBll));
        }
        // Get all
        [HttpGet("All")]
        public async Task<ActionResult<IEnumerable<Employee_DTO>>> GetEmployee_Map()
        {
            return Ok(await _employeeBll.GetEmployee_Map());
        }
        // Get sử dụng Page
        [HttpGet("Page")]
        public async Task<ActionResult<IEnumerable<Employee_DTO>>> GetEmployeePage_Map(int pageNumer = 1, int pageSize = 10)
        {
            if (pageSize > maxEmployeeSize)
            {
                pageSize = maxEmployeeSize;
            }
            return Ok(await _employeeBll.GetEmployeePage_Map(pageNumer, pageSize));
        }
        // Get sử dụng filter and Search
        [HttpGet("Filter and Search")]
        public async Task<ActionResult<IEnumerable<Employee_DTO>>> GetEmployeeNameAndSearch_Map(string employeeName, string search)
        {
            return Ok(await _employeeBll.GetEmployeeNameAndSearch_Map(employeeName, search));
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Employee_DTO>>> PostEmployee_Map(Employee_DTO employee_Post)
        {
            return Ok(await _employeeBll.PostEmployee_Map(employee_Post));
        }
        [HttpPut("UpdateEmployeeID/{ID}")]
        public async Task<ActionResult<IEnumerable<Employee_DTO>>> UpdateEmployeeID_Map(int IDEmployee, Employee_DTO employee_Update)
        {
            return Ok(await _employeeBll.UpdateEmployeeID_Map(IDEmployee, employee_Update));
        }
        [HttpDelete("DeleteEmployeeID/{ID}")]
        public async Task<ActionResult<bool>> DeleteEmployeeID(int IDEmployee)
        {
            return Ok(await _employeeBll.DeleteEmployeeID(IDEmployee));
        }
    }
}
