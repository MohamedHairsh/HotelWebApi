using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelRoomDto
    {
        public Guid HotelId { get; set; }
        public string RoomType { get; set; } = string.Empty;
        public string RoomName { get; set; } = string.Empty;
        public string BedType { get; set; } = string.Empty;
        public int MaxAdults { get; set; }
        public int MaxChildren { get; set; }
        public string RoomSize { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public string RoomStatus { get; set; } = string.Empty;
        public string RefundPolicy { get; set; } = string.Empty;
        public bool BreakfastIncluded { get; set; }
        public int AvailableRooms { get; set; }
        public string RoomImagesJson { get; set; } = string.Empty;
    }
}