using ApplicationLayer.Dto;
using BusinessLayer.IRepository;
using HotelBooking.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelController : ControllerBase
    {
        private readonly IHotelRepository _hotelRepository;

        public HotelController(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }

        [HttpPost("CreateHotel")]
        public async Task<IActionResult> CreateHotel([FromBody] HotelDto hotelDto) 
        {
            var result = await _hotelRepository.CreateHotel(hotelDto);
            var response = new ApiMessage
            {

                Message = result
            };
            return Ok(response);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllHotels()
        {
            var hotels = await _hotelRepository.GetAllHotel();
            return new JsonResult(hotels);
        }

        [HttpGet("GetHotelById")]
        public async Task<IActionResult> GetHotelById([FromQuery] Guid id)
        {
            var hotels = await _hotelRepository.GetAllById(id);
            if (hotels == null || !hotels.Any()) return NotFound("Hotel not found");
            return new JsonResult(hotels);
        }

        [HttpPut("UpdateHotel/{id}")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelDto hotelDto)
        {
            try
            {
                var updated = await _hotelRepository.UpdateHotel(id, hotelDto);
                return new JsonResult(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteHotel/{id}")]
        public async Task<IActionResult> DeleteHotel(Guid id)
        {
            try
            {
                await _hotelRepository.DeleteHotel(id);
                return Ok(new { Message = "Hotel deleted successfully (soft delete)" });
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
    }
}
