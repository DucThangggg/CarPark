using Parking_DAL.Repository;
using Parking_DAL.Repository.Implement;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.UnitOfWork
{
    public interface IParking_UnitOfWork
    {
        // Gọi EmployeeInfoRepository qua phương thức
        EmployeeInfoRepository employeeInfoRepository { get; }
        // Gọi EmployeeInfoRepository qua phương thức
        TripInfoRepository tripInfoRepository { get; }
        // Gọi BookingOfficeInfoRepository qua phương thức
        BookingInfoRepository bookingInfoRepository { get; }
        // Gọi TicketInfoRepository qua phương thức
        TicketInfoRepository ticketInfoRepository { get; }
        // Gọi ParkingLotInfoRepository qua phương thức
        ParkingLotInfoRepository parkingLotInfoRepository { get; }
        // Gọi CarInfoRepository qua phương thức
        CarInfoRepository carInfoRepository { get; }
        // Gọi UserInfoRepository qua phương thức
        UserInfoRepository userInfoRepository { get; }
        // Lưu thay đổi
        Task SaveChanges();
    }
}
