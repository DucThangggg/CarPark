using AutoMapper;
using Parking_DAL.DbContexts;
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
    public class TripBLL : ITripBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        // Hàm khởi tạo
        public TripBLL(IParking_UnitOfWork parking, IMapper mapper)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }
        public async Task<bool> DeleteTripID(int IDTrip)
        {
            // Tìm theo ID
            var _deleteTrip = await _parking.tripInfoRepository.FindIDTrip_Entities(IDTrip);
            if (_deleteTrip == null)
            {
                return false;
            }
            await _parking.tripInfoRepository.DeleteTripID(IDTrip);
            await _parking.SaveChanges();
            return true;
        }
        public async Task<IEnumerable<TripList>> GetTrip_Map()
        {
            // Gọi hàm thông qua Unit và Object TripInfoRepository khai báo ở IParkingUnitOfWork
            var employee_Entities = await _parking.tripInfoRepository.GetTrip_Entities();
            return _mapper.Map<IEnumerable<TripList>>(employee_Entities);
        }
        public async Task<IEnumerable<Trip_DTO>> GetTripPage_Map(int pageNumber, int pageSize)
        {
            // Gọi hàm thông qua Unit và Object EmployeeInfoRepository khai báo ở IParkingUnitOfWork
            var trip_Entities = await _parking.tripInfoRepository.GetTripPage_Entities(pageNumber, pageSize);
            return _mapper.Map<IEnumerable<Trip_DTO>>(trip_Entities);
        }
        // Get theo Filter and Search
        public async Task<IEnumerable<Trip_DTO>> GetTripNameAndSearch_Map(string destination, string search)
        {
            // Gọi hàm thông qua Unit và Object EmployeeInfoRepository khai báo ở IParkingUnitOfWork
            var trip_Entities = await _parking.tripInfoRepository.GetTripNameAndSearch_Entities(destination, search);
            return _mapper.Map<IEnumerable<Trip_DTO>>(trip_Entities);
        }
        public async Task<Trip_DTO> PostTrip_Map(Trip_DTO trip_Post)
        {
            var trip_post = _mapper.Map<Trip_Entities>(trip_Post);
            await _parking.tripInfoRepository.AddTrip(trip_post);
            // Lưu giá trị vào Database
            await _parking.SaveChanges();
            return _mapper.Map<Trip_DTO>(trip_post);
        }
        public async Task<Trip_DTO> UpdateTripID_Map(int IDTrip, Trip_DTO trip_Update)
        {
            // Tìm theo ID
            var trip_Entities = await _parking.tripInfoRepository.FindIDTrip_Entities(IDTrip);
            // Ánh xạ hai giá trị để thực hiện Insert
            _mapper.Map(trip_Update, trip_Entities);
            // Lưu vào giá trị là Entities
            await _parking.SaveChanges();
            return _mapper.Map<Trip_DTO>(trip_Entities);
        }
    }
}
