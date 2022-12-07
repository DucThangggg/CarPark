using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public interface IParkingLotInfoRepository
    {
        // Trả về danh sách BookingOfficeList include Trip (Địa điểm )
        Task<IEnumerable<ParkingLot_Entities>> GetParkingLotList_Entities();
        // Thêm Booking (Post)
        Task AddParkingLot(ParkingLot_Entities parking_Entities);
        // Từ parkName tìm ra hàng thông tin
        Task<ParkingLot_Entities> FindParkingWithName_Entities(string parkName);
        // Xóa theo ID
        Task DeleteParkingLotName(string parkName);
    }
}
