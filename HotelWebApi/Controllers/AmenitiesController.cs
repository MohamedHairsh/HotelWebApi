using ApplicationLayer.Dto;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using HotelBooking.Api.DTOs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AmenitiesController : ControllerBase
    {

        private IAmenitiesRepository _amenitiesRepository;
        public AmenitiesController(IAmenitiesRepository amenitiesRepository)
        {
            _amenitiesRepository = amenitiesRepository;
        }
        //[HttpPost("CreateAmenities")]
        //public async Task<IActionResult> CreateAmenities([FromBody] AmenitiesDto amenitiesDto)
        //{
        //    var result = await _amenitiesRepository.CreateAmenities(amenitiesDto);
        //    var response = new ApiMessage
        //    {
        //        Message = result
        //    };

        //    return Ok(response);
        //}


        [HttpPost("CreateAmenities")]
        public async Task<IActionResult> CreateAmenities([FromForm] AmenitiesDto amenitiesDto)
        {
            if (amenitiesDto.AmenityImageFile != null && amenitiesDto.AmenityImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "amenities");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

              
                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(amenitiesDto.AmenityImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await amenitiesDto.AmenityImageFile.CopyToAsync(stream);
                }

                
                amenitiesDto.AmenityImage = "/uploads/amenities/" + uniqueFileName;
            }

            var result = await _amenitiesRepository.CreateAmenities(amenitiesDto);
            var response = new ApiMessage
            {
                Message = result
            };

            return Ok(response);
        }

        [HttpDelete("DeleteAmenities")]
        public async Task<IActionResult> DeleteAmenities([FromQuery] Guid id)
        {
            try
            {
                await _amenitiesRepository.DeleteAmenities(id);
                return new JsonResult("Amenities Deleted Successfully");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }
        [HttpGet("GetAllBooking")]
        public async Task<IActionResult> GetAllAmenities()
        {
            var amenities = await _amenitiesRepository.GetAllAmenities();
            return new JsonResult(amenities);
        }

        [HttpPut("UpdateAmenities/{id}")]
        public async Task<IActionResult> UpdateAmenities(Guid id, [FromForm] AmenitiesDto amenitiesDto)
        {
            if (amenitiesDto.AmenityImageFile != null && amenitiesDto.AmenityImageFile.Length > 0)
            {
                var uploadsFolder = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "uploads", "amenities");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = Guid.NewGuid().ToString() + Path.GetExtension(amenitiesDto.AmenityImageFile.FileName);
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await amenitiesDto.AmenityImageFile.CopyToAsync(stream);
                }

                amenitiesDto.AmenityImage = "/uploads/amenities/" + uniqueFileName;
            }

            var result = await _amenitiesRepository.UpdateAmenities(id, amenitiesDto);

            return Ok(new ApiMessage
            {
                Message = "Amenities updated successfully",

            });
        }


    }
}
