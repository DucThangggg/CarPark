using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository
{
    public interface ITripInfoRepository
    {
        // Show Trip (Get)
        Task<IEnumerable<Trip_Entities>> GetTrip_Entities();
        Task<IEnumerable<Trip_Entities>> GetTripPage_Entities(int pageNumber, int pageSize);
        Task<IEnumerable<Trip_Entities>> GetTripNameAndSearch_Entities(string Destination, string search);
        //// trả về danh sách trip thep id
        //ienumerable<trip_entities> gettripid_entities(int idtrip);
        // Thêm Trip (Post)
        Task AddTrip(Trip_Entities trip_Entities);
        // Tìm theo ID
        Task<Trip_Entities?> FindIDTrip_Entities(int IDTrip);
        // Sửa thì dùng ánh xạ (Mapper DTO và Entities)
        // Xóa theo ID
        Task DeleteTripID(int IDTrip);
        // Tìm theo Trip suy ra IDTrip
        Task<Trip_Entities?> FindTripWithID_Entities(string trip);

    }
}
