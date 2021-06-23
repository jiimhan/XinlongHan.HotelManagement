using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;

namespace XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces
{
    public interface ICustomerRepository : IAsyncRepository<Customer>
    {
        Task<Customer> GetCustomerByEmail(string email);
        Task<List<Customer>> GetCustomerByRoomId(int roomNum);
        Task UpdateCustomer(Customer c);
    }
}
