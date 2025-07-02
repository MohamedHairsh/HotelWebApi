using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class HotelImagesController : Controller
    {
       
        private IHotelImagesRepository _hotelImagesRepository;
        public HotelImagesController(IHotelImagesRepository hotelImagesRepository)
        {
            _hotelImagesRepository = hotelImagesRepository;
        }

        [HttpPost, Route("AddHotelImages")]
        public async Task<IActionResult> AddHotelImages([FromForm] HotelImageInsertDto hotelImages)
        {
            var result = await _hotelImagesRepository.CreateHotelImages(hotelImages);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllHotelImages()
        {
            var hotelImg = await _hotelImagesRepository.GetAllHotelImagesl();
            return Ok(hotelImg);
        }

        [HttpGet, Route("GetHotelImagesById")]
        public async Task<IActionResult> GetHotelImagesById(Guid id)
        {
            var hotelImag = await _hotelImagesRepository.GetAllById(id);
            if (hotelImag == null || !hotelImag.Any()) return NotFound();
            return Ok(hotelImag);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotelImage([FromForm] HotelImageUpdateDto hotelImg)
        {
            var updated = await _hotelImagesRepository.UpdateHotelImages(hotelImg);
            return Ok(updated);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelImg(int id)
        {
            await _hotelImagesRepository.DeleteHotelImages(id);
            return Ok("Hotel deleted successfully");
        }
    }
}
