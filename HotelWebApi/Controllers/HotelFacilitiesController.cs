using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    
    public class HotelFacilitiesController : Controller
    {
        private readonly IHotelFacilitiesRepository _hotelFacilitiesRepository;

        public HotelFacilitiesController(IHotelFacilitiesRepository hotelFacilitiesRepository)
        {
            _hotelFacilitiesRepository = hotelFacilitiesRepository;
        }

        [HttpGet, Route("GetHotelFacilitiesData")]
        public async Task<IActionResult> GetHotelFacilitiesData()
        {
            var facilities = await _hotelFacilitiesRepository.GetAllHotelFacilities();
            return Ok(facilities);
        }

        [HttpPost,Route("CreateHotelFacilities")]
        public async Task<IActionResult> CreateHotelFacilities([FromBody] HotelFacilities hotelFacilities)
        {
            if (hotelFacilities == null)
            {
                return BadRequest("Hotel facilities data is null");
            }
            var result = await _hotelFacilitiesRepository.CreateHotelFacilities(hotelFacilities);
            return Ok(result);
        }
        [HttpGet,Route("GetByIdHotelFacilities")]
        public async Task<IActionResult> GetByIdHotelFacilities(Guid id)
        {
            var hotelfacilities = await _hotelFacilitiesRepository.GetAllById(id);
            if (hotelfacilities == null || !hotelfacilities.Any()) return NotFound();
            return Ok(hotelfacilities);
        }
        [HttpPut,Route("UpdateHotelFacilities")]
        public async Task<IActionResult> UpdateHotelFacilities([FromBody] HotelFacilities hotelFacilities)
        {
            var updated = await _hotelFacilitiesRepository.UpdateHotelFacilities(hotelFacilities);
            return Ok(updated);
        }
        [HttpDelete,Route("DeleteHotelFacilities")]
        public async Task<IActionResult> DeleteHotelFacilities(Guid id)
        {
            await _hotelFacilitiesRepository.DeleteHotelFacilities(id);
            return Ok("Hotel Facilities deleted successfully");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}

