using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class RoomAvailabilityDto
    {
        public Guid RoomId { get; set; }
        public DateTime Date { get; set; }
        public int AvailableCount { get; set; }
    }
}