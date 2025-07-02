using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HotelWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelRoomsController : Controller
    {
        private readonly IHotelRoomsRepository _hotelRoomRepository;
        public HotelRoomsController(IHotelRoomsRepository hotelRepository)
        {
            _hotelRoomRepository = hotelRepository;
        }
        [HttpGet]
        public async Task<IActionResult> GetHotelRoomsData()
        {
            var getdata= await _hotelRoomRepository.GetAllHotelRooms();
            return Json(getdata);
        }
        [HttpPost, Route("CreateHotelRooms")]
        public async Task<IActionResult> CreateHotelRooms([FromForm] RoomImageInsertDto roomImg)
        {
            
            var createdata = await _hotelRoomRepository.CreateHotelRooms(roomImg);

            return Ok(createdata);
        }

        [HttpGet, Route("GetHotelRoomsById")]
        public async Task<IActionResult> GetHotelRoomsById(Guid id)
        {

            var getdata = await _hotelRoomRepository.GetAllById(id);
            if (getdata == null || !getdata.Any()) return NotFound();
            return Ok(getdata);
        }

        [HttpPut, Route("UpdateHotelRooms")]
        public async Task<IActionResult> UpdateHotelRooms([FromForm] RoomImageUpdateDto roomImg)
        {
            var updated = await _hotelRoomRepository.UpdateHotelRooms(roomImg);
            return Ok(updated);
        }
        [HttpDelete, Route("DeleteHotelRooms")]
        public async Task<IActionResult> DeleteHotelRooms(Guid id)
        {
            await _hotelRoomRepository.DeleteHotelRooms(id);
            return Ok("Hotel Room deleted successfully");
        }
    }
}
