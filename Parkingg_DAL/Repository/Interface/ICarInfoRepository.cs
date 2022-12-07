using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public interface ICarInfoRepository
    {
        // Trả về danh sách CarList include ParkingLit (Bai so ??)
        Task<IEnumerable<Car_Entities>> GetCarList_Entities();
        // Thêm Ticket (Post)
        Task AddCar(Car_Entities car_Entities, ParkingLot_Entities _parkingLot_Entities);
        // Tìm theo LicensePlate trả về một hàng thông tin
        Task<Car_Entities> FindCarWithLicense_Entities(string license);
        // Xóa theo ID
        Task DeleteCarLicense(string license);
    }
}
