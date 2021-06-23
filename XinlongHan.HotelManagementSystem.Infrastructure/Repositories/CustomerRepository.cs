using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Repositories
{
    public class CustomerRepository : EfRepository<Customer>, ICustomerRepository
    {
        public CustomerRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {

        }
        public Task<Customer> GetCustomerByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Customer>> GetCustomerByRoomId(int roomNum)
        {
            var cus = await _dbContext.Customers.Where(c => c.RoomNo == roomNum).ToListAsync();
            return cus;
        }

        public async Task UpdateCustomer(Customer c)
        {
            var sql = @"UPDATE dbo.Customer SET RoomNo=@tn,CName=@n,Address=@ad,Phone=@ph,Email=@e,CheckIn=@ci,TotalPersons=@t,BookingDays=@b,Advance=@a WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@tn",c.RoomNo ?? (object)DBNull.Value),
                new SqlParameter("@n", c.CName),
                new SqlParameter("@ad", c.Address),
                new SqlParameter("@ph", c.Phone),
                new SqlParameter("@e", c.Email),
                new SqlParameter("@ci", c.Checkin ?? (object)DBNull.Value),
                new SqlParameter("@t", c.TotalPersons ?? (object)DBNull.Value),
                new SqlParameter("@b", c.BookingDays ?? (object)DBNull.Value),
                new SqlParameter("@a", c.Advance ?? (object)DBNull.Value),
                new SqlParameter("@id", c.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
