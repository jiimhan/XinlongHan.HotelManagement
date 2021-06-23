using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRoomTypeRepository _roomTypeRepository;
        private readonly IRoomRepository _roomRepository;
        public RoomService(IRoomTypeRepository roomTypeRepository, IRoomRepository roomRepository)
        {
            _roomTypeRepository = roomTypeRepository;
            _roomRepository = roomRepository;
        }
        public async Task<RoomResponse> AddRoom(RoomRequestModel request)
        {
            var room = new Room { RTCode = request.RoomTypeId, Status = request.Status };
            var type = await _roomTypeRepository.GetById(request.RoomTypeId);
            if (type == null)
                return new RoomResponse() { Message = $"RoomType {request.RoomTypeId} is not existed!" };
            var result = await _roomRepository.Add(room);
            return new RoomResponse()
            {
                Room = new RoomModel()
                {
                    Id = result.Id,
                    RoomTypeId = result.RTCode,
                    Status = result.Status
                },
                Message = "Success"
            };
        }

        public async Task<RoomTypeResponse> AddRoomType(RoomTypeRequest request)
        {
            var room = new RoomType { Id = request.Id, Rent = request.Rent, RTDesc = request.RTDESC };
            var added = await _roomTypeRepository.Add(room);
            return new RoomTypeResponse()
            {
                RoomType = added,
                Message = "Success"
            };
        }

        public async Task<ListAllRoomsResponse> GetAllRooms()
        {
            var result = await _roomRepository.ListAll();
            return new ListAllRoomsResponse()
            {
                RoomList = ConvertToModel(result),
                Message = "Success"
            };
        }

        public async Task<ListAllRoomTypeResponse> GetAllRoomTypes()
        {
            var result = await _roomTypeRepository.ListAll();
            return new ListAllRoomTypeResponse()
            {
                RoomTypeList = result,
                Message = "Success"
            };
        }

        public async Task<RoomResponse> GetRoomById(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null)
                return new RoomResponse() { Message = "Not existed" };
            return new RoomResponse()
            {
                Room = new RoomModel()
                {
                    Id = room.Id,
                    RoomTypeId = room.RTCode,
                    Status = room.Status
                },
                Message = "Success"
            };
        }

        public async Task<RoomTypeResponse> GetRoomTypeById(int id)
        {
            var type = await _roomTypeRepository.GetById(id);
            if (type == null)
                return new RoomTypeResponse() { Message = "Not existed!" };
            return new RoomTypeResponse()
            {
                RoomType = type,
                Message = "Success"
            };
        }

        public async Task<BasicResponse> RemoveRoom(int id)
        {
            var room = await _roomRepository.GetById(id);
            if (room == null)
                return new BasicResponse() { Message = $"{id} is not existed!" };
            await _roomRepository.Delete(room);
            return new BasicResponse() { Message = "Success" };
        }
        public async Task<BasicResponse> RemoveRoomType(int id)
        {
            var roomtype = await _roomTypeRepository.GetById(id);
            if (roomtype == null)
                return new BasicResponse() { Message = $"{id} is not existed!" };
            await _roomTypeRepository.Delete(roomtype);
            return new BasicResponse() { Message = "Success" };
        }

        public async Task<RoomResponse> UpdateRoom(RoomRequestModel request)
        {
            var room = await _roomRepository.GetById(request.Id);
            if (room == null)
                return new RoomResponse() { Message = $"{request.Id} is not existed!" };
            await _roomRepository.UpdateRoom(request);
            room = new Room { Id = request.Id, RTCode = request.RoomTypeId, Status = request.Status };
            return new RoomResponse()
            {
                Room = new RoomModel()
                {
                    Id = room.Id,
                    RoomTypeId = room.RTCode,
                    Status = room.Status
                },
                Message = "Success"
            };
        }

        public async Task<RoomTypeResponse> UpdateRoomType(RoomTypeRequest request)
        {
            var room = await _roomTypeRepository.GetById(request.Id);
            if (room == null)
            {
                return new RoomTypeResponse() { Message = $"{request.RTDESC} doesn't exist!" };
            }
            await _roomTypeRepository.UpdateRoomType(request);
            room = new RoomType { Id = request.Id, RTDesc = request.RTDESC, Rent = request.Rent };
            return new RoomTypeResponse()
            {
                RoomType = room,
                Message = "Success"
            };
        }

        private List<RoomModel> ConvertToModel(IEnumerable<Room> rooms)
        {
            var result = new List<RoomModel>();
            foreach (var item in rooms)
            {
                result.Add(new RoomModel()
                {
                    Id = item.Id,
                    RoomTypeId = item.RTCode,
                    Status = item.Status
                });
            }

            return result;
        }
    }
}
