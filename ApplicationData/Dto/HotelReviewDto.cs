using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelReviewDto
    {
        public Guid HotelId { get; set; }
        public Guid UserId { get; set; }
        public string ReviewerName { get; set; } = string.Empty;
        public string ReviewerCountry { get; set; } = string.Empty;
        public int Rating { get; set; }
        public string ReviewTitle { get; set; } = string.Empty;
        public string ReviewBody { get; set; } = string.Empty;
    }
}