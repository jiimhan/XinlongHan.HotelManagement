using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface IRoomService
    {
        Task<RoomTypeResponse> AddRoomType(RoomTypeRequest request);
        Task<RoomTypeResponse> UpdateRoomType(RoomTypeRequest request);
        Task<ListAllRoomTypeResponse> GetAllRoomTypes();
        Task<BasicResponse> RemoveRoomType(int id);
        Task<RoomTypeResponse> GetRoomTypeById(int id);
        Task<RoomResponse> AddRoom(RoomRequestModel request);
        Task<ListAllRoomsResponse> GetAllRooms();
        Task<BasicResponse> RemoveRoom(int id);
        Task<RoomResponse> UpdateRoom(RoomRequestModel request);
        Task<RoomResponse> GetRoomById(int id);
    }
}
