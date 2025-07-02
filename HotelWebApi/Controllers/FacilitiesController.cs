using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FacilitiesController : ControllerBase
    {

        public IFacilitiesRepository _facilitiesRepository;
        public FacilitiesController(IFacilitiesRepository facilitiesRepository)
        {
            _facilitiesRepository = facilitiesRepository;

        }

        [HttpPost, Route("CreateHotelFacilities")]
        public async Task<IActionResult> CreateHotelFacilities([FromBody] Facilities facilities)
        {
            var result = await _facilitiesRepository.CreateHotelFacilities(facilities);
            return Ok(result);
        }


        [HttpGet]
        public async Task<IActionResult> GetAllFacilities()
        {
            var hotelsFacilities = await _facilitiesRepository.GetAllFacilities();
            return Ok(hotelsFacilities);
        }



        [HttpGet, Route("GetAllById")]
        public async Task<IActionResult> GetAllById(Guid id)
        {
            var hotelsFacilities = await _facilitiesRepository.GetAllById(id);
            if (hotelsFacilities == null || !hotelsFacilities.Any()) return NotFound();
            return Ok(hotelsFacilities);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateHotelFacilities([FromBody] Facilities facilities)
        {
            var updatedFacilities= await _facilitiesRepository.UpdateHotelFacilities(facilities);

            return Ok(updatedFacilities);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteHotelFacilities(Guid id)
        {
            await _facilitiesRepository.DeleteHotelFacilities(id);
            return Ok("HotelFacilities Is deleted successfully");
        }



        
    }
}
