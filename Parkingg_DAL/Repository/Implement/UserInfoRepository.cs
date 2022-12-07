using Microsoft.EntityFrameworkCore;
using Parking_DAL.DbContexts;
using Parking_DAL.Entities;
using Parking_DAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parking_DAL.Repository.Implement
{
    public class UserInfoRepository : IUserInfoRepository
    {
        private readonly MyDbContext _context;
        public UserInfoRepository(MyDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<User_Entities?> FindUser_Entities(string userName, string password)
        {
            var _findUser = await _context.user_Entities.FirstOrDefaultAsync(p => p.UserName == userName && p.Password == password);
            return _findUser;
        }

        public async Task SignUpAnAccount(User_Entities user_Entities)
        {
            _context.user_Entities.Add(user_Entities);
        }
    }
}
