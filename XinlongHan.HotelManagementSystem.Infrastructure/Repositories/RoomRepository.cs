using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Entities;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.RepositoryInterfaces;
using XinlongHan.HotelManagementSystem.Infrastructure.Data;

namespace XinlongHan.HotelManagementSystem.Infrastructure.Repositories
{
    public class RoomRepository : EfRepository<Room>, IRoomRepository
    {
        public RoomRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task UpdateRoom(RoomRequestModel request)
        {
            var sql = @"UPDATE dbo.Room SET RTCode=@rt, Status=@s WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rt",request.RoomTypeId),
                new SqlParameter("@s", request.Status),
                new SqlParameter("@id", request.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
