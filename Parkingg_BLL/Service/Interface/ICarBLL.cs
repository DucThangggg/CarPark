using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public interface ICarBLL
    {
        // Get (Show)
        Task<IEnumerable<CarList>> GetCarList_Map();
        // Post booking
        Task<Car_DTO> PostCar_Map(Car_DTO car_Post);
        // Update Car
        Task<Car_DTO> UpdateCarID_Map(string licensePlate, Car_DTO car_Update);
        // Delete theo ID
        Task<bool> DeleteCarLicensePlate(string license);
    }
}
