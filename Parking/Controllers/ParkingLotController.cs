using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking_BLL.Service;
using Parking_DAL.DbContexts;
using Parking_DTO;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class ParkingLotController : ControllerBase
    {
        public IParkingLotBLL _parkingBll;
        // Hàm khởi tạo
        public ParkingLotController(IParkingLotBLL parkingBll)
        {
            _parkingBll = parkingBll ??
                throw new ArgumentNullException(nameof(parkingBll));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ParkingLotList>>> GetParkingLotList_Map()
        {
            return Ok(await _parkingBll.GetParkingLotList_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<ParkingLotList>>> PostParkingLot_Map(ParkingLot_DTO parking_Post)
        {
            return Ok(await _parkingBll.PostParkingLot_Map(parking_Post));
        }
        [HttpPut("UpdateParkingLot/{ParkName}")]
        public async Task<ActionResult<IEnumerable<BookingOffice_DTO>>> UpdateParkingLotName_Map(string ParkName, ParkingLot_DTO parkingLot_Update)
        {
            return Ok(await _parkingBll.UpdateParkingLotName_Map(ParkName, parkingLot_Update));
        }
        [HttpDelete("DeleteParkingLot/{ParkName}")]
        public async Task<ActionResult<bool>> DeleteParkingName(string ParkName)
        {
            return Ok(await _parkingBll.DeleteParkingName(ParkName));
        }
    }
}
