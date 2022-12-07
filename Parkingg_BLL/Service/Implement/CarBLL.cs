using AutoMapper;
using Parking_DAL.Entities;
using Parking_DAL.UnitOfWork;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public class CarBLL : ICarBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        // Hàm khởi tạo
        public CarBLL(IParking_UnitOfWork parking, IMapper mapper)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> DeleteCarLicensePlate(string license)
        {
            // Tìm theo License
            var _deleteCar = await _parking.carInfoRepository.FindCarWithLicense_Entities(license);
            if (_deleteCar == null)
            {
                return false;
            }
            await _parking.carInfoRepository.DeleteCarLicense(license);
            await _parking.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<CarList>> GetCarList_Map()
        {
            // Gọi hàm thông qua Unit và Object CarInfoRepository khai báo ở IParkingUnitOfWork
            var car_Entities = await _parking.carInfoRepository.GetCarList_Entities();
            return _mapper.Map<IEnumerable<CarList>>(car_Entities);
        }
        public async Task<Car_DTO> PostCar_Map(Car_DTO car_Post)
        {
            // car_Post là Object Car_DTO được thêm vào, chấm ParkName là gọi biến trong Object ParkingLot đó
            var carEntities = await _parking.parkingLotInfoRepository.FindParkingWithName_Entities(car_Post.ParkName);
            // Từ Id thêm vào thì tìm ra ID của bookingEntities, ban đầu booking_Post không có ai đi, bên phải là thêm ID vào bên trái để Mapper
            var carPost = _mapper.Map<Car_Entities>(car_Post);
            await _parking.carInfoRepository.AddCar(carPost, carEntities);
            // Lưu giá trị vào Database
            await _parking.SaveChanges();
            return _mapper.Map<Car_DTO>(carPost);
        }
        public async Task<Car_DTO> UpdateCarID_Map(string licensePlate, Car_DTO car_Update)
        {
            // Tìm theo ID
            var car_Entities = await _parking.carInfoRepository.FindCarWithLicense_Entities(licensePlate);
            // Ánh xạ hai giá trị để thực hiện Insert
            _mapper.Map(car_Update, car_Entities);
            // Lưu vào giá trị là Entities
            await _parking.SaveChanges();
            return _mapper.Map<Car_DTO>(car_Entities);
        }
    }
}
