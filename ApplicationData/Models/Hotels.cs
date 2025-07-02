using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class Hotels
    {
        [Key]
        public Guid HotelId { get; set; }
        public string? HotelName { get; set; }
        public string? ShortDescription { get; set; }
        public string? Description { get; set; }
        public string? HotelType { get; set; }
        public int? StarRating { get; set; }
        public string? HotelChain { get; set; }
        public string? LogoUrl { get; set; }
        public string? CoverImageUrl { get; set; }
        public string? Country { get; set; }
        public string? StateOrProvince { get; set; }
        public string? City { get; set; }
        public string? AddressLine1 { get; set; }
        public string? AddressLine2 { get; set; }
        public string? PostalCode { get; set; }
        public decimal? Latitude { get; set; }
        public decimal? Longitude { get; set; }
        public string? Email { get; set; }
        public string? PrimaryPhone { get; set; }
        public string? WebsiteUrl { get; set; }
        public TimeSpan? CheckInTime { get; set; }
        public TimeSpan? CheckOutTime { get; set; }
        public string? CovidSafetyLevel { get; set; }
        public string? AcceptedCurrencies { get; set; }
        public string? LanguagesSpoken { get; set; }
        public bool? IsActive { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
