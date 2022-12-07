using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service
{
    public interface IParkingLotBLL
    {
        // Get (Show)
        Task<IEnumerable<ParkingLotList>> GetParkingLotList_Map();
        // Post ParkingLot
        Task<ParkingLot_DTO> PostParkingLot_Map(ParkingLot_DTO parking_Post);
        // Update ParkingLot
        Task<ParkingLot_DTO> UpdateParkingLotName_Map(string parkName, ParkingLot_DTO parkingLot_Update);
        // Delete theo ID
        Task<bool> DeleteParkingName(string parkName);
    }
}
