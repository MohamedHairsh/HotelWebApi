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
    public class StaffController : ControllerBase
    {
        private IStaffRepository _staffRepository;
        public StaffController(IStaffRepository staffRepository)
        {
            _staffRepository = staffRepository;
        }

        [HttpPost("CreateStaff")]
        public async Task<IActionResult> CreateStaff([FromForm] StaffDto staffDto)
        {
            var result = await _staffRepository.CreateStaff(staffDto);
            return Ok(new { Message = result });
        }
        [HttpPut("UpdateStaff/{id}")]
        public async Task<IActionResult> UpdateStaff(Guid id, [FromForm] StaffDto staffDto)
        {
            var updatedStaff = await _staffRepository.UpdateStaff(id, staffDto);
            if (updatedStaff == null) return NotFound();
            return Ok(updatedStaff);
        }

        [HttpGet]

        public async Task<IActionResult> GetAllStaff()
        {
            var staffList = await _staffRepository.GetAllStaff();
            return Ok(staffList);
        }

        [HttpDelete("DeleteStaff")]
        public async Task<IActionResult> DeleteStaff([FromQuery] Guid id)
        {
            try
            {
                await _staffRepository.DeleteStaff(id);
                return new JsonResult("Staff Deleted Successfully");
            }
            catch (Exception ex)
            {

                return NotFound(ex.Message);
            }
        }




    }
}
