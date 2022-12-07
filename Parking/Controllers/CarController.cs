using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Parking_BLL.Service;
using Parking_DTO;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    [Authorize]
    [ApiController]
    public class CarController : ControllerBase
    {
        public ICarBLL _carBll;
        // Hàm khởi tạo
        public CarController(ICarBLL carBll)
        {
            _carBll = carBll ??
                throw new ArgumentNullException(nameof(carBll));
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CarList>>> GetCarList_Map()
        {
            return Ok(await _carBll.GetCarList_Map());
        }
        [HttpPost]
        public async Task<ActionResult<IEnumerable<Car_DTO>>> PostCar_Map(Car_DTO car_Post)
        {
            return Ok(await _carBll.PostCar_Map(car_Post));
        }
        [HttpPut("UpdateCar/{licensePlate}")]
        public async Task<ActionResult<IEnumerable<Car_DTO>>> UpdateCarID_Map(string licensePlate, Car_DTO car_Update)
        {
            return Ok(await _carBll.UpdateCarID_Map(licensePlate, car_Update));
        }
        [HttpDelete("DeleteCar/{LicensePlate}")]
        public async Task<ActionResult<bool>> DeleteCarLicensePlate(string LicensePlate)
        {
            return Ok(await _carBll.DeleteCarLicensePlate(LicensePlate));
        }
    }
}
