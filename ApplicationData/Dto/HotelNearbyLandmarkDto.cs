using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelNearbyLandmarkDto
    {
        public Guid HotelId { get; set; }
        public string LandmarkName { get; set; } = string.Empty;
        public decimal DistanceInKm { get; set; }
        public string LandmarkType { get; set; } = string.Empty;
    }
}