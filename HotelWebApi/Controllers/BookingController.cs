using ApplicationLayer.Dto;
using BusinessLayer.IRepository;
using HotelBooking.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using ApplicationLayer.Common;
using Microsoft.AspNetCore.Authorization;

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
        [Authorize(Roles = "Admin,Customer")]
        [HttpGet("GetAllBooking")]
        public async Task<IActionResult> GetAllbooking()
        {
            var book = await _bookingRepository.GetAllBooking();
            return new JsonResult(book);
        }
        [HttpPut("UpdateBooking")]
        public async Task<IActionResult> UpdateBooking([FromQuery] Guid id, [FromBody] BookingDto bookingDto)
        {
            try
            {
                var updatedBooking = await _bookingRepository.UpdateBooking(id, bookingDto);
                return Ok(updatedBooking);
            }
            catch (Exception ex)
            {
                return NotFound(new { Message = ex.Message });
            }
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById(Guid id)
        {
            try
            {
                var booking = await _bookingRepository.GetAllById(id);
                return Ok(booking);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound(new { message = ex.Message });
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = "An error occurred.", error = ex.Message });
            }
            //partial view reusable small portion of ui("_LoginPartial");

            //Layout View  => master template for designing ("_Layou")

        }


    }
}
