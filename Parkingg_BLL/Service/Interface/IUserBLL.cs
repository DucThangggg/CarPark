using Parking_DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service.Interface
{
    public interface IUserBLL
    {
        // Post User
        Task<User_DTO> SignUpAnAccount_Map(User_DTO user_Post);
        // SignIn
        Task<string> SignInAnAnccount(User_DTO user_Post);
    }
}
