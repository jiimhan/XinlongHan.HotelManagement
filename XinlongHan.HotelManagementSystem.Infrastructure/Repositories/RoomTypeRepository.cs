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
    public class RoomTypeRepository : EfRepository<RoomType>, IRoomTypeRepository
    {
        public RoomTypeRepository(HotelManagementDbContext dbContext) : base(dbContext)
        {

        }

        public async Task<RoomType> GetByName(string name)
        {
            try
            {
                var result = await _dbContext.RoomTypes.FirstOrDefaultAsync(r => r.RTDesc == name);
                return result;
            }
            catch (Exception e)
            {
                return null;
            }
        }

        public async Task UpdateRoomType(RoomTypeRequest request)
        {
            var sql = @"UPDATE dbo.RoomType SET RTDESC=@rt, Rent=@rent WHERE Id=@id";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@rt",request.RTDESC),
                new SqlParameter("@rent", request.Rent),
                new SqlParameter("@id", request.Id)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
