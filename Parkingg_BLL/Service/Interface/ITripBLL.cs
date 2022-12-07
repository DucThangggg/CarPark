using Parking_DAL.DbContexts;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public interface ITripBLL
    {
        // Get (Show)
        Task<IEnumerable<TripList>> GetTrip_Map();
        Task<IEnumerable<Trip_DTO>> GetTripPage_Map(int pageNumber, int pageSize);
        Task<IEnumerable<Trip_DTO>> GetTripNameAndSearch_Map(string destination, string search);
        // Post theo ID
        Task<Trip_DTO> PostTrip_Map(Trip_DTO trip_Post);
        // Update theo ID
        Task<Trip_DTO> UpdateTripID_Map(int IDTrip, Trip_DTO trip_Update);
        // Delete theo ID
        Task<bool> DeleteTripID(int IDTrip);
    }
}
