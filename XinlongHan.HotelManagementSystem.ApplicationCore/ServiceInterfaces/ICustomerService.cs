using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces
{
    public interface ICustomerService
    {
        Task<CustomerResponse> AddCustomer(CustomerRequest request);
        Task<CustomerResponse> UpdateCustomer(CustomerRequest request);
        Task<BasicResponse> DeleteCustomer(int id);
        Task<ListAllCustomer> GetAllCustomers();
        Task<CustomerResponse> GetCustomerById(int id);
    }
}
