using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelPolicyDto
    {
        public Guid HotelId { get; set; }
        public string PolicyType { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
    }
}