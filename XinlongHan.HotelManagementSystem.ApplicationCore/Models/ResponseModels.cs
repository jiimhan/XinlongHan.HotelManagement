using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.Models
{
    public class BasicResponse
    {
        public string Message { get; set; }
        public int StatusCode { get; set; }
    }

    public class CustomerResponse : BasicResponse
    {
        public int Id { get; set; }
        public int? RoomNo { get; set; }
        public string CName { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime? CheckIn { get; set; }
        public int? TotalPersons { get; set; }
        public int? BookingDays { get; set; }
        public decimal? Advance { get; set; }
    }

    public class ListAllCustomer : BasicResponse
    {
        public List<CustomerModel> CustomerList { get; set; }
    }

    public class CustomerModel
    {
        public int Id { get; set; }
        public string CName { get; set; }
    }

    public class RoomAndServiceInfoResponseModel
    {
        public Room Room { get; set; }
        public IEnumerable<Roomservice> RoomService { get; set; }
    }
    public class UserLoginResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class UserRegisterResponseModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
    public class ServiceResponse : BasicResponse
    {
        public ServiceModel Service { get; set; }
    }
    public class ServiceModel
    {
        public int Id { get; set; }
        public int? RoomId { get; set; }
        public decimal? Amount { get; set; }
        public string SDESC { get; set; }
        public DateTime? ServiceDate { get; set; }
    }
    public class ListServicesResponse : BasicResponse
    {
        public List<ServiceModel> List { get; set; }
    }

    public class RoomTypeResponse : BasicResponse
    {
        public RoomType RoomType { get; set; }
    }

    public class ListAllRoomTypeResponse : BasicResponse
    {
        public IEnumerable<RoomType> RoomTypeList { get; set; }
    }
    public class RoomResponse : BasicResponse
    {
        public RoomModel Room { get; set; }
    }

    public class RoomModel
    {
        public int Id { get; set; }
        public int RoomTypeId { get; set; }
        public bool? Status { get; set; }
    }

    public class ListAllRoomsResponse : BasicResponse
    {
        public IEnumerable<RoomModel> RoomList { get; set; }
    }
}
