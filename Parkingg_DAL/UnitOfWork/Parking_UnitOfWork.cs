using Parking_DAL.DbContexts;
using Parking_DAL.Repository;
using Parking_DAL.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.UnitOfWork
{
    public class Parking_UnitOfWork : IParking_UnitOfWork, IDisposable
    {
        // _context giá trị của client nhập vào
        private readonly MyDbContext _context;
        // Khai báo trường cho object EmployeeInfoRepository
        private EmployeeInfoRepository _employeeInfoRepository;
        // Khai báo trường cho object TripInfoRepository
        private TripInfoRepository _tripInfoRepository;
        // Khai báo trường cho object TripInfoRepository
        private BookingInfoRepository _bookingInfoRepository;
        // Khai báo trường cho object TicketInfoRepository
        private TicketInfoRepository _ticketInfoRepository;
        // Khai báo trường cho object TicketInfoRepository
        private ParkingLotInfoRepository _parkingLotInfoRepository;
        // Khai báo trường cho object CarInfoRepository
        private CarInfoRepository _carInfoRepository;
        // Khai báo trường cho object UserInfoRepository
        private UserInfoRepository _userInfoRepository;

        // Hàm khởi tạo ProductInfoRepository
        public EmployeeInfoRepository employeeInfoRepository
        {
            get
            {
                _employeeInfoRepository = new EmployeeInfoRepository(_context);
                return _employeeInfoRepository;
            }
        }
        // Hàm khởi tạo TripInfoRepository
        public TripInfoRepository tripInfoRepository
        {
            get
            {
                _tripInfoRepository = new TripInfoRepository(_context);
                return _tripInfoRepository;
            }
        }
        // Hàm khởi tạo BookingInfoRepository
        public BookingInfoRepository bookingInfoRepository
        {
            get
            {
                _bookingInfoRepository = new BookingInfoRepository(_context);
                return _bookingInfoRepository;
            }
        }
        // Hàm khởi tạo TikcetInfoRepository
        public TicketInfoRepository ticketInfoRepository
        {
            get
            {
                _ticketInfoRepository = new TicketInfoRepository(_context);
                return _ticketInfoRepository;
            }
        }
        // Hàm khởi tạo ParkingLotInfoRepository
        public ParkingLotInfoRepository parkingLotInfoRepository
        {
            get
            {
                _parkingLotInfoRepository = new ParkingLotInfoRepository(_context);
                return _parkingLotInfoRepository;
            }
        }
        // Hàm khởi tạo CarInfoRepository
        public CarInfoRepository carInfoRepository
        {
            get
            {
                _carInfoRepository = new CarInfoRepository(_context);
                return _carInfoRepository;
            }
        }
        // Hàm khởi tạo UserInfoRepository
        public UserInfoRepository userInfoRepository
        {
            get
            {
                _userInfoRepository = new UserInfoRepository(_context);
                return _userInfoRepository;
            }
        }
        public Parking_UnitOfWork(MyDbContext context)
        {
            _context = context;
        }
        //Save vào CSDL
        public async Task SaveChanges()
        {
            await _context.SaveChangesAsync();
        }
        public void Dispose()
        {
            _context.Dispose();
            //Console.ForegroundColor = ConsoleColor.Red;
            //Console.WriteLine("Dispose");
            //Console.ResetColor();
        }
    }
}
