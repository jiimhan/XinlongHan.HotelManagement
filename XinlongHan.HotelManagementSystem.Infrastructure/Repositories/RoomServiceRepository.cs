using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.Infrastructure.Data;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Repositories
{
    public class RoomServiceRepository : EfRepository<Roomservice>, IRoomServiceRepository
    {
        public RoomServiceRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Roomservice> GetServicesByRoomAndDate(int roomId, DateTime date)
        {
            var result = await _dbContext.RoomServices.Where(s => s.RoomNo == roomId && s.ServiceDate == date).FirstOrDefaultAsync();
            return result;
        }

        public async Task UpdateService(Roomservice services)
        {
            var sql = @"UPDATE dbo.Service SET [RoomNo]=@rn,[SDESC]=@d,[ServiceDate]=@sd,[Amount]=@am WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rn",services.RoomNo ?? (object)DBNull.Value),
                new SqlParameter("@sd", services.ServiceDate ?? (Object)DBNull.Value),
                new SqlParameter("@am", services.Amount ?? (object)DBNull.Value),
                new SqlParameter("@d", services.SDesc),
                new SqlParameter("@id", services.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
