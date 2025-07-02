using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelNearbyLandmarks
    {
        [Key]

        public Guid LandmarkId { get; set; }

        public string? HotelId  { get; set; }
        public string?LandmarkName { get; set; }

        public decimal?  DistanceInKm { get; set; }

        public string? LandmarkType { get; set; }


    }
}
