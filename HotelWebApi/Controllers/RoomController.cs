using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using ApplicationLayer.Models.Enum;
using BusinessLayer.IRepository;
using HotelBooking.Api.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RoomController : ControllerBase
    {
        private readonly IRoomRepository _roomRepository;

        public RoomController(IRoomRepository roomRepository)
        {
            _roomRepository = roomRepository;
        }

        [HttpPost("CreateRoom")]
        public async Task<IActionResult> CreateRoom([FromBody] HotelRoomDto roomDto)
        {
            var result = await _roomRepository.CreateRoom(roomDto);
            var response = new ApiMessage
            {
                Message = result
            };
            return Ok(response);
        }

        [HttpGet("GetAllRooms")]
        public async Task<IActionResult> GetAllRoom()
        {
            var rooms = await _roomRepository.GetAllRoom();

            if (rooms == null || !rooms.Any())
                return NotFound("No rooms found");

            return Ok(rooms);
        }




        [HttpGet("GetRoomById")]
        public async Task<IActionResult> GetHotelById([FromQuery] Guid id)
        {
            var rooms = await _roomRepository.GetAllById(id);
            if (rooms == null || !rooms.Any()) return NotFound("Room not found");
            return new JsonResult(rooms);
        }

        [HttpPut("UpdateRoom/{id}")]
        public async Task<IActionResult> UpdateHotel(Guid id, [FromBody] HotelRoomDto roomDto)
        {
            try
            {
                var updated = await _roomRepository.UpdateHotel(id, roomDto);
                return new JsonResult(updated);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }


        [HttpDelete("DeleteHotel")]
        public async Task<IActionResult> DeleteHotel([FromQuery] Guid id)
        {
            try
            {
                await _roomRepository.DeleteHotel(id);
                return new JsonResult("Room deleted successfully");
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpPost("AddRoomType")]
        public async Task<IActionResult> AddRoomType([FromBody] MasterRoomDto masterRoom)
        {
            var result = await _roomRepository.AddRoomType(masterRoom);
            var response = new ApiMessage
            {
                Message = result
            };
            return Ok(response);
        }

        [HttpGet("GetAllRoomType")]
        public async Task<IActionResult> GetAllRoomType()
        {
            var data = await _roomRepository.GetRoomType();
            return new JsonResult(data);
        }

        [HttpPost("AddBedType")]
        public async Task<IActionResult> AddBedType([FromBody] MasterBedDto masterBed)
        {
            var result = await _roomRepository.AddBedType(masterBed);
            var response = new ApiMessage
            {
                Message = result
            };
            return Ok(response);
        }

        [HttpGet("GetAllBedType")]
        public async Task<IActionResult> GetAllBedType()
        {
            var data = await _roomRepository.GetBedType();
            return new JsonResult(data);
        }

        [HttpDelete("MasterRoomDelete/{type}/{id}")]

        public async Task<IActionResult> DeleteMaster(string type, Guid id)
        {
            if (!Enum.TryParse<MasterType>(type, true, out var masterType))
                return BadRequest("Invalid master type");

            var deleted = await _roomRepository.DeleteMasterAsync(masterType, id);
            if (!deleted)
                return NotFound("Record not found");

            return NoContent();
        }


        [HttpPut("MasterRoomUpdate/{type}/{id}")]

        public async Task<IActionResult> UpdateMaster(string type, Guid id, [FromBody] MasterUpdateDto dto)
        {
            if (!Enum.TryParse<MasterType>(type, true, out var masterType))
                return BadRequest("Invalid master type");

            var updated = await _roomRepository.UpdateMasterAsync(masterType, id, dto.Name);
            if (!updated)
                return NotFound("Record not found");

            return Ok("Updated successfully");
        }
    }
}
