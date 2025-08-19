using ApplicationLayer.Dto;
using BusinessLayer.IRepository;
using HotelBooking.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Common;

namespace HotelWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BookingController : ControllerBase
    {
        private IBookingRepository _bookingRepository;
        public BookingController(IBookingRepository bookingRepository)
        {
                _bookingRepository = bookingRepository;
        }
        [HttpPost("CreateBooking")]
        public async Task<IActionResult> CreateBooking([FromBody] BookingDto bookingDto)
        {
            var result = await _bookingRepository.CreateBooking(bookingDto);
            var response = new ApiMessage
            {
                Message = result
            };

            return Ok(response);
        }

        [HttpDelete("DeleteBookingDetails")]
        public async Task<IActionResult> DeleteBooking([FromQuery] Guid id)
        {
            try
            {
                await _bookingRepository.DeleteBooking(id);
                return new JsonResult("Booking Details Deleted Successfully");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }

        [HttpGet("GetAllBooking")]
        public async Task<IActionResult> GetAllbooking()
        {
            var book = await _bookingRepository.GetAllBooking();
            return new JsonResult(book);
        }
    }
}
