using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HotelNearbyLandmarksController : ControllerBase
    {

        


        private IHotelNearbyLandmarks _hotelLandmarks;

       
        public HotelNearbyLandmarksController(IHotelNearbyLandmarks hotelNearbyLandmarks)
        {
            _hotelLandmarks = hotelNearbyLandmarks;
        }

        //  Task<List<HotelNearbyLandmarks>> GetAllHotelNearbyLandmarks();

        //  public async Task<List<HotelNearbyLandmarks>> GetAllHotelNearbyLandmarks()
        //{
        // return await _db.HotelNearbyLandmarks.ToListAsync();
        // }





        [HttpPost, Route("CreateHotelNearbyLandmarks")]
        public async Task<IActionResult> CreateHotelNearbyLandmarks([FromBody] HotelNearbyLandmarks hotelNearbyLandmarks)
        {
            var result = await _hotelLandmarks.CreateHotelNearbyLandmarks(hotelNearbyLandmarks);
            return Ok(result);
        }


        [HttpGet]

        public async Task<IActionResult> GetAllHotelNearbyLandmarks()
        {

            var NearByLandMarks = await _hotelLandmarks.GetAllHotelNearbyLandmarks();
            return Ok(NearByLandMarks);
        }



       

        

        

        [HttpGet, Route("GetAllById")]
        public async Task<IActionResult> GetAllById(Guid id)
        {
            var hotelLandmark = await _hotelLandmarks.GetAllById(id);
            if (hotelLandmark == null || !hotelLandmark.Any()) return NotFound();
            return Ok(hotelLandmark);
        }

       

        //[HttpPut]
        //public async Task<IActionResult> UpdateHotelNearbyLandmarks([FromBody] HotelNearbyLandmarks hotelNearbyLandmarks)
        //{
        //    if (!ModelState.IsValid)
        //        return BadRequest(ModelState);

        //    try
        //    {
        //        var updated = await _hotelLandmarks.UpdateHotelNearbyLandmarks(hotelNearbyLandmarks);
        //        return Ok(updated);
        //    }
        //    catch (Exception ex)
        //    {
        //        return NotFound(ex.Message);
        //    }
        //}

        [HttpPut]
        public async Task<IActionResult> UpdateHotelNearbyLandmarks([FromBody] HotelNearbyLandmarks hotelNearbyLandmarks)
        {
            var updatedLAndMark = await _hotelLandmarks.UpdateHotelNearbyLandmarks(hotelNearbyLandmarks);
            return Ok(updatedLAndMark);
        }
         [HttpDelete]
        public async Task<IActionResult> DeleteHoteLandMark(Guid id)
        {
            await _hotelLandmarks.DeleteHoteLandMark(id);
            return Ok("HotelLandMark deleted successfully");
        }

    }
}
