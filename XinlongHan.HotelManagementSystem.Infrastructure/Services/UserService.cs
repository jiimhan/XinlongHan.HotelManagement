using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserLoginResponseModel> Login(string email, string password)
        {
            var user = await _userRepository.GetUserByEmail(email);

            if (user == null)
            {
                return null;
            }
            var hashedPassword = CreateHashedPassword(password, user.Salt);
            if (hashedPassword == user.HashedPassword)
            {
                var loginResponseModel = new UserLoginResponseModel
                {
                    Id = user.Id,
                    Email = user.Email,
                    FirstName = user.FirstName,
                    LastName = user.LastName
                };
                return loginResponseModel;
            }
            return null;
        }
        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }
        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel userRegisterRequestModel)
        {
            // check user is not in database
            var dbUser = await _userRepository.GetUserByEmail(userRegisterRequestModel.Email);
            if (dbUser != null)
            {
                throw new Exception(" User already exist!");
            }
            var salt = CreateSalt();
            var hashedPassword = CreateHashedPassword(userRegisterRequestModel.Password, salt);

            var user = new User
            {
                FirstName = userRegisterRequestModel.FirstName,
                LastName = userRegisterRequestModel.LastName,
                Email = userRegisterRequestModel.Email,
                Salt = salt,
                HashedPassword = hashedPassword
            };
            var createdUser = await _userRepository.Add(user);
            var response = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName,
                Email = createdUser.Email
            };
            return response;
        }
    }
}
