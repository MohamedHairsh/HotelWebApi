using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomAvailabilityController : Controller
    {
        private IRoomAvailabilityRepository _roomAvailabilityRepository;
        public RoomAvailabilityController(IRoomAvailabilityRepository roomAvailabilityRepository)
        {
            _roomAvailabilityRepository = roomAvailabilityRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateRoomAvailability([FromBody] RoomAvailability roomAvailability)
        {
            var result = await _roomAvailabilityRepository.CreateRoomAvailability(roomAvailability);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRoomAvailability()
        {
            var hotels = await _roomAvailabilityRepository.GetAllRoomAvailability();
            return Ok(hotels);
        }

        [HttpGet, Route("GetRoomAvailabilityById")]
        public async Task<IActionResult> GetRoomAvailabilityById(Guid id)
        {
            var hotels = await _roomAvailabilityRepository.GetAllByIdRoomAvailability(id);
            if (hotels == null || !hotels.Any()) return NotFound();
            return Ok(hotels);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateRoomAvailability([FromBody] RoomAvailability roomAvailability)
        {
            var updated = await _roomAvailabilityRepository.UpdateRoomAvailability(roomAvailability);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRoomAvailability(Guid id)
        {
            await _roomAvailabilityRepository.DeleteRoomAvailability(id);
            return Ok("Room Availability deleted successfully");
        }
    }
}
