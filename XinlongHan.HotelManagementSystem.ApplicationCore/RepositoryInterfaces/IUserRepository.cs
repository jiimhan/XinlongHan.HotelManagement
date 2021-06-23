using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces
{
    public interface IUserRepository : IAsyncRepository<User>
    {
        Task<User> GetUserByEmail(string email);
    }
}
