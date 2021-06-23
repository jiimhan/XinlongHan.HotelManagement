using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces
{
    public interface IRoomServiceRepository : IAsyncRepository<Roomservice>
    {
        Task<Roomservice> GetServicesByRoomAndDate(int roomId, DateTime date);
        Task UpdateService(Roomservice services);
    }
}
