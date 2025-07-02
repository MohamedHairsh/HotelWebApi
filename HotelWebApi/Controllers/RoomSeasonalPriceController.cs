using ApplicationLayer.Models;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.AspNetCore.Mvc;

namespace HotelWebApi.Controllers
{

    public class RoomSeasonalPriceController : Controller
    {
        private readonly IRoomSeasonalPricesRepository _roomSeasonalPricesRepository;
        public RoomSeasonalPriceController(IRoomSeasonalPricesRepository roomSeasonalPricesRepository)
        {
            _roomSeasonalPricesRepository = roomSeasonalPricesRepository;
        }
        [HttpGet, Route("GetRoomSeasonalPricesData")]
        public async Task<IActionResult> GetRoomSeasonalPricesData()
        {
            var facilities = await _roomSeasonalPricesRepository.GetAllRoomSeasonalPrices();
            return Ok(facilities);
        }
        [HttpPost,Route("CreateRoomSeasonalPrices")]
        public async Task<IActionResult> CreateRoomSeasonalPrices([FromBody] RoomSeasonalPrices roomSeasonalPrices)
        {
            if (roomSeasonalPrices == null)
            {
                return BadRequest("Room facilities data is null");
            }
            var result = await _roomSeasonalPricesRepository.CreateRoomSeasonalPrices(roomSeasonalPrices);
            return Ok(result);
        }
        [HttpGet,Route("GetByIdRoomSeasonalPrices")]
        public async Task<IActionResult> GetByIdRoomSeasonalPrices(Guid id)
        {
            var roomSeasonalPrices = await _roomSeasonalPricesRepository.GetAllByIdRoomSeasonalPrices(id);
            if (roomSeasonalPrices == null || !roomSeasonalPrices.Any()) return NotFound();
            return Ok(roomSeasonalPrices);
        }
        [HttpPut,Route("UpdateRoomSeasonalPrices")]
        public async Task<IActionResult> UpdateRoomSeasonalPrices([FromBody] RoomSeasonalPrices roomSeasonalPrices)
        {
            var updated = await _roomSeasonalPricesRepository.UpdateRoomSeasonalPrices(roomSeasonalPrices);
            return Ok(updated);
        }
        [HttpDelete,Route("DeleteRoomSeasonalPrices")]
        public async Task<IActionResult> DeleteRoomSeasonalPrices(Guid id)
        {
            await _roomSeasonalPricesRepository.DeleteRoomSeasonalPrices(id);
            return Ok("Room Seasonal Prices deleted successfully");
        }
        public IActionResult Index()
        {
            return View();
        }
    }
}
