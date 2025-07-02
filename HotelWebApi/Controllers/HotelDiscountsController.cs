using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelDiscountsController : ControllerBase
    {

        private IHotelDiscountRepository _hotelDiscountRepository;
        public HotelDiscountsController(IHotelDiscountRepository hotelRepository)
        {
            _hotelDiscountRepository = hotelRepository;
        }

        [HttpPost, Route("CreateHotelDiscount")]
        public async Task<IActionResult> CreateHotelDiscount([FromBody] HotelDiscounts hotelDiscounts)
        {
            var result = await _hotelDiscountRepository.CreateHotelDiscount(hotelDiscounts);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllDiscount()
        {
            var hotelsDicount = await _hotelDiscountRepository.GetAllDiscount();
            return Ok(hotelsDicount);
        }

        [HttpGet, Route("GetHotelById")]
        public async Task<IActionResult> GetAllById(Guid id)
        {
            var hotelsDiscount = await _hotelDiscountRepository.GetAllById(id);
            if (hotelsDiscount == null || !hotelsDiscount.Any()) return NotFound();
            return Ok(hotelsDiscount);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotelDiscount([FromBody] HotelDiscounts hotelDiscounts)
        {
            var updated = await _hotelDiscountRepository.UpdateHotelDiscount(hotelDiscounts);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelDiscount(Guid id)
        {
            await _hotelDiscountRepository.DeleteHotelDiscount(id);
            return Ok("Hotel Discount deleted successfully");
        }

    }
}
