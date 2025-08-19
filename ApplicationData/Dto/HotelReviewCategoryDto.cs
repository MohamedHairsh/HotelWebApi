using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelReviewCategoryDto
    {
        public Guid ReviewId { get; set; }
        public string Category { get; set; } = string.Empty;
        public int Score { get; set; }
    }
}