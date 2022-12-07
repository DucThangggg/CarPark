using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Parking_BLL.Service;
using Parking_BLL.Service.Interface;
using Parking_DTO;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Parking.Controllers
{
    [Route("api/[controller]")]
    //[Authorize]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {
        public IUserBLL _userBll;
        // Hàm khởi tạo
        public AuthenticationController(IUserBLL userBll)
        {
            _userBll = userBll ??
                throw new ArgumentNullException(nameof(userBll));
        }
        [HttpPost("SignUpAccount")]
        public async Task<ActionResult<IEnumerable<User_DTO>>> SignUpAnAccount_Map(User_DTO user_Post)
        {
            return Ok(await _userBll.SignUpAnAccount_Map(user_Post));
        }
        [HttpPost("SignInAccount")]
        public async Task<ActionResult<string>> SignInAnAnccount(User_DTO user_Post)
        {
            return Ok(await _userBll.SignInAnAnccount(user_Post));
        }
    }
}
