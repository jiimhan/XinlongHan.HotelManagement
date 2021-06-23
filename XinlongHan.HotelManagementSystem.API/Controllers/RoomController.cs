using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using XinlongHan.HotelManagementSystem.ApplicationCore.ServiceInterfaces;
using XinlongHan.HotelManagementSystem.ApplicationCore.Models;

namespace XinlongHan.HotelManagementSystem.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private IRoomService _roomService;

        public RoomController(IRoomService roomService)
        {
            _roomService = roomService;
        }
        [HttpPost("AddRoom")]
        public async Task<IActionResult> AddRoom(RoomRequestModel request)
        {
            var result = await _roomService.AddRoom(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpPut("UpdateRoom")]
        public async Task<IActionResult> UpdateRoom(RoomRequestModel request)
        {
            var result = await _roomService.UpdateRoom(request);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpDelete("RemoveRoom")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            var result = await _roomService.RemoveRoom(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpGet("ListRooms")]
        public async Task<IActionResult> ListAllRooms()
        {
            var result = await _roomService.GetAllRooms();
            return Ok(result.RoomList);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetRoomById(int id)
        {
            var result = await _roomService.GetRoomById(id);
            if (result.Message != "Success")
                return NotFound(result);
            return Ok(result);
        }
    }
}
