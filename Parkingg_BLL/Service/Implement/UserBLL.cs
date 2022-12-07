using AutoMapper;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using Parking_BLL.Service.Interface;
using Parking_DAL.Entities;
using Parking_DAL.UnitOfWork;
using Parking_DTO;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Parking_BLL.Service.Implement
{
    public class UserBLL : IUserBLL
    {
        public IParking_UnitOfWork _parking;
        public IMapper _mapper;
        public IConfiguration _configuration;
        // Hàm khởi tạo
        public UserBLL(IParking_UnitOfWork parking, IMapper mapper, IConfiguration configuration)
        {
            _parking = parking ??
                throw new ArgumentNullException(nameof(parking));
            _mapper = mapper ??
                throw new ArgumentNullException(nameof(mapper));
            _configuration = configuration ??
                throw new ArgumentNullException(nameof(configuration));
        }

        public async Task<User_DTO> SignUpAnAccount_Map(User_DTO user_Post)
        {
            var userPost = _mapper.Map<User_Entities>(user_Post);
            await _parking.userInfoRepository.SignUpAnAccount(userPost);
            // Lưu giá trị vào Database
            await _parking.SaveChanges();
            return _mapper.Map<User_DTO>(userPost);
        }
        public async Task<string> SignInAnAnccount(User_DTO user_Post)
        {
            // step 1: Tìm theo UserName and Password
            var _findUser = await _parking.userInfoRepository.FindUser_Entities(user_Post.UserName, user_Post.Password);
            if (_findUser == null)
            {
                return null;
            }
            // Step 2: create a token
            var securityKey = new SymmetricSecurityKey(
                Encoding.ASCII.GetBytes(_configuration["Authentication:SecretForkey"]));
            var signingCredentials = new SigningCredentials(
                securityKey, SecurityAlgorithms.HmacSha256);

            // The claims that
            var claimsForToken = new List<Claim>();
            claimsForToken.Add(new Claim("name", _findUser.UserName));
            claimsForToken.Add(new Claim("password", _findUser.Password));
            claimsForToken.Add(new Claim("role", _findUser.Role));
            claimsForToken.Add(new Claim("firstname", _findUser.FirstName));
            claimsForToken.Add(new Claim("lastname", _findUser.LastName));
            claimsForToken.Add(new Claim("phone", _findUser.Phone.ToString()));

            var jwtSecurityToken = new JwtSecurityToken(
                _configuration["Authentication:Issuer"],
                _configuration["Authentication:Audience"],
                claimsForToken,
                DateTime.UtcNow,
                DateTime.UtcNow.AddHours(1),
                signingCredentials);

            var tokenToReturn = new JwtSecurityTokenHandler().
                WriteToken(jwtSecurityToken);
            return tokenToReturn;
        }
    }
}
