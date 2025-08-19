using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelRatingsSummaryDto
    {
        public decimal AverageRating { get; set; }
        public int TotalReviews { get; set; }
    }
}