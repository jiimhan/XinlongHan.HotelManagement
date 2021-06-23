using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface IRoomServiceService
    {
        Task<ServiceResponse> AddService(ServiceRequest request);
        Task<ServiceResponse> UpdateService(ServiceRequest request);
        Task<ServiceModel> GetServiceByRoomAndDate(int room, DateTime date);
        Task<BasicResponse> DeleteService(int id);
        Task<ListServicesResponse> GetAllService();
        Task<ServiceResponse> GetServiceById(int id);
    }
}
