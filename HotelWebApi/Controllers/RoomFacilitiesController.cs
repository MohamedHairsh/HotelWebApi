using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    public class RoomFacilitiesController : Controller
    {
        private readonly IRoomFacilitiesRepository _roomFacilitiesRepository;

        public RoomFacilitiesController(IRoomFacilitiesRepository roomFacilitiesRepository)
        {
            _roomFacilitiesRepository = roomFacilitiesRepository;
        }

        [HttpGet,Route("GetRoomFacilitiesData")]
        public async Task<IActionResult> GetRoomFacilitiesData()
        {
            var facilities = await _roomFacilitiesRepository.GetAllRoomFacilities();
            return Ok(facilities);
        }
        [HttpPost,Route("CreateRoomFacilities")]
        public async Task<IActionResult> CreateRoomFacilities([FromBody] RoomFacilities roomFacilities)
        {
            if (roomFacilities == null)
            {
                return BadRequest("Room facilities data is null");
            }
            var result = await _roomFacilitiesRepository.CreateRoomFacilities(roomFacilities);
            return Ok(result);
        }
        [HttpGet, Route("GetByIdRoomFacilities")]
        public async Task<IActionResult> GetByIdRoomFacilities(Guid id)
        {
            var roomFacilities = await _roomFacilitiesRepository.GetAllByIdRoomFacilities(id);
            if (roomFacilities == null || !roomFacilities.Any()) return NotFound();
            return Ok(roomFacilities);
        }
        [HttpPut,Route("UpdateRoomFacilities")]
        public async Task<IActionResult> UpdateRoomFacilities([FromBody] RoomFacilities roomFacilities)
        {
            var updated = await _roomFacilitiesRepository.UpdateRoomFacilities(roomFacilities);
            return Ok(updated);
        }
        [HttpDelete,Route("DeleteRoomFacilities")]
        public async Task<IActionResult> DeleteRoomFacilities(Guid id)
        {
            await _roomFacilitiesRepository.DeleteRoomFacilites(id);
            return Ok("Room Facilities deleted successfully");
        }


        public IActionResult Index()
        {
            return View();
        }
    }
}
