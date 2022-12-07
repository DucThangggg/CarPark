using Microsoft.EntityFrameworkCore;
using Parking_DAL.DbContexts;
using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public class CarInfoRepository : ICarInfoRepository
    {
        private readonly MyDbContext _context;
        public CarInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public async Task AddCar(Car_Entities car_Entities, ParkingLot_Entities parkingLot_Entities)
        {
            parkingLot_Entities.ListCar.Add(car_Entities);
            // Khi thêm Car có dùng ParkName thì ParkStatus tự tăng lên theo thứ tự
            parkingLot_Entities.ParkStatus = parkingLot_Entities.ListCar.Count.ToString();
        }
        // Get Car include thêm ParkingLot
        public async Task<IEnumerable<Car_Entities>> GetCarList_Entities()
        {
            // Get Car ( một List)
            return await _context.car_Entities.Include(x => x.parkingLot_Entities).ToListAsync();
        }
        // Từ LicensePlate trae về một car_Entities
        public async Task<Car_Entities> FindCarWithLicense_Entities(string license)
        {
            // Từ Destination trả về một Trip_Entities
            var _carEntites = await _context.car_Entities.Include(x => x.ListTicket).FirstOrDefaultAsync(p => p.LicensePlate == license);
            return _carEntites;
        }
        public async Task DeleteCarLicense(string license)
        {
            // Trả về một Object Entities
            var _deleteCar = await _context.car_Entities.FirstOrDefaultAsync(p => p.LicensePlate == license);
            if (_deleteCar != null)
            {
                _context.car_Entities.Remove(_deleteCar);
            }
        }
    }
}
