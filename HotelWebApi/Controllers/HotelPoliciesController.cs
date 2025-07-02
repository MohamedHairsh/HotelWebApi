using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelPoliciesController : Controller
    {
        private  IHotelPoliciesRopository _hotelPoliciesRepository;
        public HotelPoliciesController(IHotelPoliciesRopository hotelPoliciesRepository)
        {
            _hotelPoliciesRepository = hotelPoliciesRepository;
        }


        [HttpPost, Route("CreateHotelPolicies")]
        public async Task<IActionResult> CreateHotelPolicies([FromBody] HotelPolicies hotel)
        {
            var result = await _hotelPoliciesRepository.CreateHotelPolicies(hotel);
            return Ok(result);
        }
        [HttpGet]
        public async Task<IActionResult> GetAllHotelPolicies()
        {
            var hotelPolicies = await _hotelPoliciesRepository.GetAllHotelPolicies();
            return Ok(hotelPolicies);
        }
        [HttpGet, Route("GetHotelPoliciesById")]
        public async Task<IActionResult> GetHotelPoliciesById(Guid id)
        {
            var hotelPolicies = await _hotelPoliciesRepository.GetAllById(id);
            if (hotelPolicies == null || !hotelPolicies.Any()) return NotFound(); 
            return Ok(hotelPolicies);
        }
        [HttpPut, Route("UpdateHotelPolicies")]
        public async Task<IActionResult> UpdateHotelPolicies([FromBody] HotelPolicies hotelPolicies)
        {
            var updated = await _hotelPoliciesRepository.UpdateHotelPolicies(hotelPolicies);
            return Ok(updated);
        }
        [HttpDelete, Route("DeleteHotelPolicies")]
        public async Task<IActionResult> DeleteHotelPolicies(Guid id)
        {
            await _hotelPoliciesRepository.DeleteHotelPolicies(id);
            return Ok("Hotel Policies deleted successfully");
        }
      
    }
}
