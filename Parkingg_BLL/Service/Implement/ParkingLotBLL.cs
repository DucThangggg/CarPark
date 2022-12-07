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
    public class ParkingLotBLL : IParkingLotBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        // Hàm khởi tạo
        public ParkingLotBLL(IParking_UnitOfWork parking, IMapper mapper)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> DeleteParkingName(string parkName)
        {
            // Tìm theo ID
            var _deleteparking = await _parking.parkingLotInfoRepository.FindParkingWithName_Entities(parkName);
            if (_deleteparking == null)
            {
                return false;
            }
            await _parking.parkingLotInfoRepository.DeleteParkingLotName(parkName);
            await _parking.SaveChanges();
            return true;
        }
        // Get
        public async Task<IEnumerable<ParkingLotList>> GetParkingLotList_Map()
        {
            // Gọi hàm thông qua Unit và Object ParkingLotInfoRepository khai báo ở IParkingUnitOfWork
            var parkingLot_Entities = await _parking.parkingLotInfoRepository.GetParkingLotList_Entities();
            return _mapper.Map<IEnumerable<ParkingLotList>>(parkingLot_Entities);
        }
        public async Task<ParkingLot_DTO> PostParkingLot_Map(ParkingLot_DTO parking_Post)
        {
            var parkingPost = _mapper.Map<ParkingLot_Entities>(parking_Post);
            await _parking.parkingLotInfoRepository.AddParkingLot(parkingPost);
            // Lưu giá trị vào Database
            await _parking.SaveChanges();
            return _mapper.Map<ParkingLot_DTO>(parkingPost);
        }
        public async Task<ParkingLot_DTO> UpdateParkingLotName_Map(string parkName, ParkingLot_DTO parkingLot_Update)
        {
            // Tìm theo ID
            var parkingLot_Entities = await _parking.parkingLotInfoRepository.FindParkingWithName_Entities(parkName);
            // Ánh xạ hai giá trị để thực hiện Insert
            _mapper.Map(parkingLot_Update, parkingLot_Entities);
            // Lưu vào giá trị là Entities
            await _parking.SaveChanges();
            return _mapper.Map<ParkingLot_DTO>(parkingLot_Entities);
        }
    }
}
