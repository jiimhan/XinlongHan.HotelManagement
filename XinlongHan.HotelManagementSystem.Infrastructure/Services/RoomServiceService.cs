using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Services
{
    public class RoomServiceService : IRoomServiceService
    {
        private readonly IRoomServiceRepository _roomServiceRepository;
        private readonly IRoomRepository _roomRepository;
        public RoomServiceService(IRoomServiceRepository roomServiceRepository, IRoomRepository roomRepository)
        {
            _roomServiceRepository = roomServiceRepository;
            _roomRepository = roomRepository;
        }

        public async Task<ServiceResponse> AddService(ServiceRequest request)
        {

            var add = new Roomservice
            {
                Id = request.Id,
                RoomNo = request.RoomNo,
                Amount = request.Amount,
                SDesc = request.SDESC,
                ServiceDate = request.ServiceDate
            };
            if (request.RoomNo != null)
            {
                var room = await _roomRepository.GetById(request.RoomNo.Value);
                if (room == null)
                    return new ServiceResponse() { Message = "Room is not existed!" };
            }
            var added = await _roomServiceRepository.Add(add);
            if (added == null)
                return new ServiceResponse() { Message = "Add failed!" };
            var response = MapServiceResponse(added);
            response.Message = "Success";
            return response;
        }

        private ServiceResponse MapServiceResponse(Roomservice services)
        {
            var ser = new ServiceModel()
            {
                Id = services.Id,
                RoomId = services.RoomNo,
                SDESC = services.SDesc,
                ServiceDate = services.ServiceDate,
                Amount = services.Amount
            };
            return new ServiceResponse() { Service = ser };
        }

        public async Task<ServiceModel> GetServiceByRoomAndDate(int room, DateTime date)
        {
            var service = await _roomServiceRepository.GetServicesByRoomAndDate(room, date);
            if(service != null)
            {
                var result = new ServiceModel
                {
                    Id = service.Id,
                    RoomId = service.RoomNo,
                    Amount = service.Amount,
                    SDESC = service.SDesc,
                    ServiceDate = service.ServiceDate
                };
                return result;
            } else
            {
                return new ServiceModel { };
            }
        }

        public async Task<ServiceResponse> UpdateService(ServiceRequest request)
        {
            var update = new Roomservice
            {
                Id = request.Id,
                RoomNo = request.RoomNo,
                Amount = request.Amount,
                SDesc = request.SDESC,
                ServiceDate = request.ServiceDate
            };
            if (request.RoomNo != null)
            {
                var room = await _roomRepository.GetById(request.RoomNo.Value);
                if (room == null)
                    return new ServiceResponse() { Message = "Room is not existed!" };
            }
            await _roomServiceRepository.UpdateService(update);
            var response = MapServiceResponse(update);
            response.Message = "Success";
            return response;
        }

        public async Task<BasicResponse> DeleteService(int id)
        {
            var service = await _roomServiceRepository.GetById(id);
            await _roomServiceRepository.Delete(service);
            return new BasicResponse() { Message = "Success" };
        }

        public async Task<ListServicesResponse> GetAllService()
        {
            var sers = await _roomServiceRepository.ListAll();
            var list = new List<ServiceModel>();
            foreach (var item in sers)
            {
                list.Add(new ServiceModel
                {
                    Id = item.Id,
                    RoomId = item.RoomNo,
                    SDESC = item.SDesc,
                    ServiceDate = item.ServiceDate,
                    Amount = item.Amount
                });
            }

            return new ListServicesResponse()
            {
                List = list,
                Message = "Success"
            };
        }

        public async Task<ServiceResponse> GetServiceById(int id)
        {
            var ser = await _roomServiceRepository.GetById(id);
            var response = MapServiceResponse(ser);
            response.Message = "Success";
            return response;
        }
    }
}
