using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces
{
    public interface IRoomTypeRepository : IAsyncRepository<RoomType>
    {
        Task<RoomType> GetByName(string name);
        Task UpdateRoomType(RoomTypeRequest request);
    }
}
