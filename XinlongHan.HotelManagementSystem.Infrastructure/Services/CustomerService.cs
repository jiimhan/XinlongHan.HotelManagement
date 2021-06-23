using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using XinlongHan.HotelManagementSystem.Infrastructure.Repositories;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Services
{
    public class CustomerService : ICustomerService
    {

        private readonly ICustomerRepository _customerRepository;
        private readonly IRoomRepository _roomRepository;
        private readonly IRoomServiceService _roomServiceService;
        private readonly IRoomTypeRepository _roomTypeRepository;
        public CustomerService(ICustomerRepository customerRepository, IRoomRepository roomRepository,
            IRoomServiceService roomServiceService, IRoomTypeRepository roomTypeRepository)
        {
            _customerRepository = customerRepository;
            _roomRepository = roomRepository;
            _roomServiceService = roomServiceService;
            _roomTypeRepository = roomTypeRepository;
        }

        public async Task<CustomerResponse> AddCustomer(CustomerRequest request)
        {
            if (!CheckParam(request))
                return new CustomerResponse() { Message = "Parameter is missing!" };
            if (request.RoomId != null)
            {
                var room = await _roomRepository.GetById(request.RoomId.Value);
                if (room != null)
                {
                    if (room.Status.Value)
                    {
                        room.Status = false;
                        await _roomRepository.Update(room);
                        var type = await _roomTypeRepository.GetById(room.RTCode);
                        await AddService(request, type.Rent);
                    }
                    else
                    {
                        var cuss = await _customerRepository.GetCustomerByRoomId(room.Id);

                        if (!CheckRoomStatus(cuss, request.CheckIn.Value, request.BookingDays.Value))
                            return new CustomerResponse() { Message = "Room has been booked!" };
                        else
                        {
                            var type = await _roomTypeRepository.GetById(room.RTCode);
                            await AddService(request, type.Rent);
                        }
                    }

                }
                else
                {
                    return new CustomerResponse() { Message = "Room is not existed!" };
                }
            }
            var cus = new Customer
            {
                Id = request.Id,
                Email = request.Email,
                Advance = request.Advance,
                BookingDays = request.BookingDays,
                Checkin = request.CheckIn,
                CName = request.CName,
                Phone = request.Phone,
                Address = request.Address,
                RoomNo = request.RoomId,
                TotalPersons = request.TotalPersons
            };
            var result = await _customerRepository.Add(cus);
            var response = new CustomerResponse
            {
                Id = result.Id,
                RoomNo = result.RoomNo,
                CName = result.CName,
                Address = result.Address,
                Phone = result.Phone,
                Email = result.Email,
                CheckIn = result.Checkin,
                TotalPersons = result.TotalPersons,
                BookingDays = result.BookingDays,
                Advance = result.Advance
            };
            response.Message = "Success";
            return response;
        }


        private async Task AddService(CustomerRequest request, decimal? rent)
        {
            var amount = rent ?? 0 + request.Advance ?? 0;
            var servicereq = new ServiceRequest()
            {
                RoomNo = request.RoomId,
                SDESC = $"{request.CName} book room with advanced {request.Advance ?? 0}",
                Amount = amount,
                ServiceDate = request.CheckIn
            };

            await _roomServiceService.AddService(servicereq);
        }
        public async Task<BasicResponse> DeleteCustomer(int id)
        {
            var cus = await _customerRepository.GetById(id);
            if (cus.RoomNo != null)
                await CanceledRoom(cus.RoomNo.Value, id);
            await _customerRepository.Delete(cus);
            return new BasicResponse() { Message = "Success" };
        }
        public async Task<ListAllCustomer> GetAllCustomers()
        {
            var result = await _customerRepository.ListAll();
            var list = new List<CustomerModel>();
            foreach (var item in result)
            {
                list.Add(new CustomerModel()
                {
                    CName = item.CName,
                    Id = item.Id
                });
            }
            return new ListAllCustomer()
            {
                CustomerList = list,
                Message = "Success"
            };
        }

        public async Task<CustomerResponse> GetCustomerById(int id)
        {
            var result = await _customerRepository.GetById(id);
            var response = new CustomerResponse
            {
                Id = result.Id,
                RoomNo = result.RoomNo,
                CName = result.CName,
                Address = result.Address,
                Phone = result.Phone,
                Email = result.Email,
                CheckIn = result.Checkin,
                TotalPersons = result.TotalPersons,
                BookingDays = result.BookingDays,
                Advance = result.Advance
            };
            response.Message = "Success";
            return response;
        }
        public async Task<CustomerResponse> UpdateCustomer(CustomerRequest request)
        {
            if (!CheckParam(request))
                return new CustomerResponse() { Message = "Parameter is missing!" };
            if (!await UpdateRoom(request))
                return new CustomerResponse() { Message = "Room has been booked!" };

            var result = new Customer
            {
                Id = request.Id,
                Email = request.Email,
                Advance = request.Advance,
                BookingDays = request.BookingDays,
                Checkin = request.CheckIn,
                CName = request.CName,
                Phone = request.Phone,
                Address = request.Address,
                RoomNo = request.RoomId,
                TotalPersons = request.TotalPersons
            };
            await _customerRepository.UpdateCustomer(result);
            var response = new CustomerResponse
            {
                Id = result.Id,
                RoomNo = result.RoomNo,
                CName = result.CName,
                Address = result.Address,
                Phone = result.Phone,
                Email = result.Email,
                CheckIn = result.Checkin,
                TotalPersons = result.TotalPersons,
                BookingDays = result.BookingDays,
                Advance = result.Advance
            };
            response.Message = "Success";
            return response;
        }



        private async Task CanceledRoom(int roomId, int cusId)
        {
            var cus = await _customerRepository.GetCustomerByRoomId(roomId);
            if (cus.Count == 1 && cus[0].Id == cusId)
            {
                var room = await _roomRepository.GetById(roomId);
                room.Status = true;
                var update = new RoomRequestModel
                {
                    Id = room.Id,
                    RoomTypeId = room.RTCode,
                    Status = room.Status
                };
                await _roomRepository.UpdateRoom(update);
            }
        }
        private bool CheckParam(CustomerRequest request)
        {
            if (request.RoomId == 0)
                request.RoomId = null;
            if (request.RoomId != null)
            {
                if (request.CheckIn == null || request.BookingDays == null)
                    return false;
            }
            return true;
        }
        private bool CheckRoomStatus(List<Customer> customers, DateTime date, int days)
        {
            foreach (var item in customers)
            {
                if (item.Checkin != null)
                {
                    if ((date > item.Checkin.Value && date < item.Checkin.Value.AddDays(item.BookingDays.Value)) ||
                        (date.AddDays(days) > item.Checkin.Value && date < item.Checkin.Value) ||
                        (date < item.Checkin.Value.AddDays(item.BookingDays.Value) && date.AddDays(days) > item.Checkin.Value.AddDays(item.BookingDays.Value)))
                        return false;
                }
            }
            return true;
        }
        private async Task<bool> UpdateRoom(CustomerRequest request)
        {
            var old = await _customerRepository.GetById(request.Id);
            if (old.RoomNo != null)
            {
                if (request.RoomId == null)
                {
                    await CanceledRoom(old.RoomNo.Value, old.Id);
                }
                else if (request.RoomId.Value != old.RoomNo.Value)
                {
                    var room = await _roomRepository.GetById(request.RoomId.Value);
                    if (room.Status.Value)
                    {
                        await CanceledRoom(old.RoomNo.Value, old.Id);
                        await BookRoom(request.RoomId.Value);
                    }
                    else
                    {
                        var cuss = await _customerRepository.GetCustomerByRoomId(room.Id);

                        if (!CheckRoomStatus(cuss, request.CheckIn.Value, request.BookingDays.Value))
                            return false;
                    }
                    var type = await _roomTypeRepository.GetById(room.RTCode);
                    await UpdateService(request, old.RoomNo.Value, old.Checkin.Value, type.Rent);
                }
            }
            else
            {
                if (request.RoomId != null)
                {
                    var room = await _roomRepository.GetById(request.RoomId.Value);
                    if (room.Status.Value)
                        await BookRoom(room.Id);
                    else
                    {
                        var cuss = await _customerRepository.GetCustomerByRoomId(room.Id);

                        if (!CheckRoomStatus(cuss, request.CheckIn.Value, request.BookingDays.Value))
                            return false;
                    }
                    var type = await _roomTypeRepository.GetById(room.RTCode);
                    await AddService(request, type.Rent);
                }
            }
            return true;
        }
        private async Task UpdateService(CustomerRequest request, int oldroom, DateTime oldtime, decimal? rent)
        {
            var ser = await _roomServiceService.GetServiceByRoomAndDate(oldroom, oldtime);
            if (ser != null)
            {
                var amount = rent ?? 0 + request.Advance ?? 0;
                var servicereq = new ServiceRequest()
                {
                    Id = ser.Id,
                    RoomNo = request.RoomId,
                    SDESC = $"{request.CName} book room with advanced {request.Advance ?? 0}",
                    Amount = amount,
                    ServiceDate = request.CheckIn
                };

                await _roomServiceService.UpdateService(servicereq);
            }
            else
                await AddService(request, rent);
        }
        private async Task BookRoom(int roomId)
        {
            var room = await _roomRepository.GetById(roomId);
            room.Status = false;
            var update = new RoomRequestModel
            {
                Id = room.Id,
                RoomTypeId = room.RTCode,
                Status = room.Status
            };
            await _roomRepository.UpdateRoom(update);
        }
    }
}
