using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Models;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelRoomFullDto : HotelRoom
    {
        public List<Facility> Facilities { get; set; } = new();
        public List<RoomSeasonalPrice> SeasonalPrices { get; set; } = new();
    }
}