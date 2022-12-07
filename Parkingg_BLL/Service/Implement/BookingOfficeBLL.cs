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
    public class BookingOfficeBLL : IBookingOfficeBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        // Hàm khởi tạo
        public BookingOfficeBLL(IParking_UnitOfWork parking, IMapper mapper)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<bool> DeleteBookingOfficeID(int IDBookingOffice)
        {
            // Tìm theo ID
            var _deletebooking = await _parking.bookingInfoRepository.FindIDBookingOffice_Entities(IDBookingOffice);
            if (_deletebooking == null)
            {
                return false;
            }
            await _parking.bookingInfoRepository.DeleteBookingOfficeID(IDBookingOffice);
            await _parking.SaveChanges();
            return true;
        }

        public async Task<IEnumerable<BookingOfficeList>> GetBookingOfficeList_Map()
        {
            // Gọi hàm thông qua Unit và Object TripInfoRepository khai báo ở IParkingUnitOfWork
            var booking_Entities = await _parking.bookingInfoRepository.GetBookingOfficeList_Entities();
            return _mapper.Map<IEnumerable<BookingOfficeList>>(booking_Entities);
        }
        public async Task<BookingOffice_DTO> PostBookingOffice_Map(BookingOffice_DTO booking_Post)
        {
            // booking_Post là Object BookingOffice_DTO được thêm vào, chấm Destination là gọi biến trong Object Booking đó
            var bookingEntities = await _parking.tripInfoRepository.FindTripWithID_Entities(booking_Post.Destination);
            // Từ Id thêm vào thì tìm ra ID của bookingEntities, ban đầu booking_Post không có ai đi, bên phải là thêm ID vào bên trái để Mapper
            //booking_Post.TripId = bookingEntities.TripId;
            var bookingPost = _mapper.Map<BookingOffice_Entities>(booking_Post);
            await _parking.bookingInfoRepository.AddBooking(bookingPost, bookingEntities);
            // Lưu giá trị vào Database
            await _parking.SaveChanges();
            return _mapper.Map<BookingOffice_DTO>(bookingPost);
        }
        // Giá trị Update phải có ID và Destination trùng với trip_Entities, chỉ thay đổi các thông số khác
        public async Task<BookingOffice_DTO> UpdateBookingOfficeID_Map(int IDBooking, BookingOffice_DTO booking_Update)
        {
            // Tìm theo ID
            var booking_Entities = await _parking.bookingInfoRepository.FindIDBookingOffice_Entities(IDBooking);
            // Ánh xạ hai giá trị để thực hiện Insert
            _mapper.Map(booking_Update, booking_Entities);
            // Lưu vào giá trị là Entities
            await _parking.SaveChanges();
            return _mapper.Map<BookingOffice_DTO>(booking_Entities);
        }
    }
}
