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
    public class ServiceController : ControllerBase
    {
        private readonly IRoomServiceService _roomServiceService;

        public ServiceController(IRoomServiceService roomServiceService)
        {
            _roomServiceService = roomServiceService;
        }

        [HttpPost("AddService")]
        public async Task<IActionResult> AddService(ServiceRequest request)
        {
            var result = await _roomServiceService.AddService(request);
            return Ok(result);
        }

        [HttpPut("UpdateService")]
        public async Task<IActionResult> UpdateService(ServiceRequest request)
        {
            var result = await _roomServiceService.UpdateService(request);
            return Ok(result);
        }

        [HttpDelete("DeleteService")]
        public async Task<IActionResult> DeleteService(int id)
        {
            var result = await _roomServiceService.DeleteService(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }

        [HttpGet("GetAllServices")]
        public async Task<IActionResult> GetAllServices()
        {
            var result = await _roomServiceService.GetAllService();
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result.List);
        }

        [HttpGet("GetById")]
        public async Task<IActionResult> GetServiceById(int id)
        {
            var result = await _roomServiceService.GetServiceById(id);
            if (result.Message != "Success")
                return Conflict(result);
            return Ok(result);
        }
    }
}
