using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : Controller
    {
        private IHotelRepository _hotelRepository;
        public HotelController(IHotelRepository hotelRepository)
        {
                _hotelRepository = hotelRepository;
        }

        [HttpPost,Route("CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] Hotels hotel)
        {
            var result = await _hotelRepository.CreateHotel(hotel);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAllHotel();
            return Ok(hotels);
        }

        [HttpGet,Route("GetHotelById")]
        public async Task<IActionResult> GetHotelById(Guid id)
        {
            var hotels = await _hotelRepository.GetAllById(id);
            if (hotels == null || !hotels.Any()) return NotFound();
            return Ok(hotels);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotel([FromBody] Hotels hotel)
        {
            var updated = await _hotelRepository.UpdateHotel(hotel);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            await _hotelRepository.DeleteHotel(id);
            return Ok("Hotel deleted successfully");
        }
    }
}
