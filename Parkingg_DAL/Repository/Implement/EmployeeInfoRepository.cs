using Microsoft.EntityFrameworkCore;
using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Parking_DAL.DbContexts;
using Microsoft.VisualBasic;

namespace Parking_DAL.Repository
{
    public class EmployeeInfoRepository : IEmployeeInfoRepository
    {
        private readonly MyDbContext _context;
        public EmployeeInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddEmployee(Employee_Entities employee_Entities)
        {
            _context.employee_Entities.Add(employee_Entities);
        }
        ////Trả về theo ID
        //public async Task<IEnumerable<Employee_Entities>> GetEmployeeID_Entities(int IDEmployee)
        //{
        //    return await _context.employee_Entities.Where(p => p.EmployeeId == IDEmployee).ToListAsync();
        //}
        public async Task DeleteEmployeeID(int IDEmployee)
        {
            // Trả về một Object Entities
            var _deleteEmployee = await _context.employee_Entities.FirstOrDefaultAsync(p => p.EmployeeId == IDEmployee);
            if (_deleteEmployee != null)
            {
                _context.employee_Entities.Remove(_deleteEmployee);
            }
        }
        public async Task<Employee_Entities?> FindIDEmployee_Entities(int IDEmployee)
        {
            //var _FindEmployee = await _context.employee_Entities.Include(x => x.abc).FirstOrDefaultAsync(p => p.EmployeeId == IDEmployee);
            //var mn = _FindEmployee.abc.abcID;
            var _FindEmployee = await _context.employee_Entities.FirstOrDefaultAsync(p => p.EmployeeId == IDEmployee);
            return _FindEmployee;
        }
        public async Task<IEnumerable<Employee_Entities>> GetEmployee_Entities()
        {
            return await _context.employee_Entities.ToListAsync();
        }
        // PageNumber là số trang hiện tại ( vd: 2/10), pageSize là độ dài của một trang
        public async Task<IEnumerable<Employee_Entities>> GetEmployeePage_Entities(int pageNumber, int pageSize)
        {
            return await _context.employee_Entities.OrderBy(c => c.EmployeeName).
                Skip(pageSize * (pageNumber - 1)).
                Take(pageSize).ToListAsync();
        }
        // Tìm kiếm string nào đó trong database và lọc theo Name
        public async Task<IEnumerable<Employee_Entities>> GetEmployeeNameAndSearch_Entities(string employeeName, string search)
        {
            if(string.IsNullOrEmpty(employeeName) && string.IsNullOrWhiteSpace(search))
            {
                return await GetEmployee_Entities();
            }
            // collection to start from
            var collection = _context.employee_Entities as IQueryable<Employee_Entities>;
            if (!string.IsNullOrWhiteSpace(employeeName))
            {
                employeeName = employeeName.Trim();
                collection = collection.Where(c => c.EmployeeName == employeeName);
            } 
            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.Trim();
                collection = collection.Where(a => a.EmployeeName.Contains(search)
                    || (a.EmployeeAddress != null && a.EmployeeAddress.Contains(search)));
            } 
            return await collection.OrderBy(c => c.EmployeeName).ToListAsync();
        }
    }
}
