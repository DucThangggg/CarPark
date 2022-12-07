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
    public class TripController : ControllerBase
    {
        public ITripBLL _tripBll;
        // Hàm khởi tạo
        public TripController(ITripBLL tripBll)
        {
            _tripBll = tripBll ??
                throw new ArgumentNullException(nameof(tripBll));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<TripList>>> GetTrip_Map()
        {
            return Ok(await _tripBll.GetTrip_Map());
        }
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<Trip_DTO>>> GetTripNameAndSearch_Map(string destination, string search)
        //{
        //    return Ok(await _tripBll.GetTripNameAndSearch_Map(destination, search));
        //}
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Trip_DTO>>> PostEmployee_Map(Trip_DTO trip_Post)
        {
            return Ok(await _tripBll.PostTrip_Map(trip_Post));
        }
        [HttpPut("UpdateTrip/{IDTrip}")]
        public async Task<ActionResult<IEnumerable<Trip_DTO>>> UpdateTripID_Map(int IDTrip, Trip_DTO trip_Update)
        {
            return Ok(await _tripBll.UpdateTripID_Map(IDTrip, trip_Update));
        }
        [HttpDelete("DeleteTrip/{IDTrip}")]
        public async Task<ActionResult<bool>> DeleteTripID(int IDTrip)
        {
            return Ok(await _tripBll.DeleteTripID(IDTrip));
        }
    }
}
