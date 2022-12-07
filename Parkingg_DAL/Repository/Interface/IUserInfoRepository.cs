using Parking_DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository.Interface
{
    public interface IUserInfoRepository
    {
        // Thêm User (Post)
        Task SignUpAnAccount(User_Entities user_Entities);
        // Tìm theo UserName and Password
        Task<User_Entities?> FindUser_Entities(string userName, string password);
    }
}
