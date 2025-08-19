using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace ApplicationLayer.Dto
{
    public class HotelDto
    {
        public Guid HotelAdminId { get; set; }
        public string HotelName { get; set; } = string.Empty;
        public string ShortDescription { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string HotelType { get; set; } = string.Empty;
        public int StarRating { get; set; }
        public string HotelChain { get; set; } = string.Empty;
        public string LogoUrl { get; set; } = string.Empty;
        public string CoverImageUrl { get; set; } = string.Empty;
        public string Country { get; set; } = string.Empty;
        public string StateOrProvince { get; set; } = string.Empty;
        public string City { get; set; } = string.Empty;
        public string AddressLine1 { get; set; } = string.Empty;
        public string AddressLine2 { get; set; } = string.Empty;
        public string PostalCode { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Email { get; set; } = string.Empty;
        public string PrimaryPhone { get; set; } = string.Empty;
        public string WebsiteUrl { get; set; } = string.Empty;
        public TimeSpan CheckInTime { get; set; }
        public TimeSpan CheckOutTime { get; set; }
        public string CovidSafetyLevel { get; set; } = string.Empty;
        public string AcceptedCurrencies { get; set; } = string.Empty;
        public string LanguagesSpoken { get; set; } = string.Empty;
        public bool IsActive { get; set; }
    }
}