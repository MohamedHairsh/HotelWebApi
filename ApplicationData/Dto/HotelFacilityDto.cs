using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelFacilityDto
    {
        public Guid HotelId { get; set; }
        public Guid FacilityId { get; set; }
        public bool IsAvailable { get; set; }
    }
}