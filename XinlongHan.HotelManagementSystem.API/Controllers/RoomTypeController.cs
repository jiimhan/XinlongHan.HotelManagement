using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;

namespace XinlongHan.HotelManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomTypeController : ControllerBase
    {
        private readonly IRoomService _roomService;

        public RoomTypeController(IRoomService roomService)
        {
            _roomService = roomService;
        }

        [HttpPost("AddRoomType")]
        public async Task<IActionResult> AddRoomType(RoomTypeRequest request)
        {
            var result = await _roomService.AddRoomType(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpDelete("DeleteRoomType")]
        public async Task<IActionResult> RemoveRoomType(int id)
        {
            var result = await _roomService.RemoveRoomType(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPut("UpdateRoomType")]
        public async Task<IActionResult> UpdateRoomType(RoomTypeRequest request)
        {
            var result = await _roomService.UpdateRoomType(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpGet("GetAllRoomTypes")]
        public async Task<IActionResult> GetAllRoomTyps()
        {
            var result = await _roomService.GetAllRoomTypes();
            return Ok(result.RoomTypeList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetTypeById(int id)
        {
            var result = await _roomService.GetRoomTypeById(id);
            if (result.Message != "Success")
                return NotFound(result);
            return Ok(result);
        }
    }
}
