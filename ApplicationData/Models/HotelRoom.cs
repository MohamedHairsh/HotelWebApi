using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelRoom
    {
        [Key]
        public Guid RoomId { get; set; }
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
        public DateTime CreatedDate { get; set; }
        public Guid CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }
        public Guid? ModifiedBy { get; set; }
    }
}