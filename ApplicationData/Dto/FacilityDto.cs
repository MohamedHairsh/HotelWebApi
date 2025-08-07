using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class FacilityDto
    {
        public string FacilityName { get; set; } = string.Empty;
        public string Category { get; set; } = string.Empty;
    }
}