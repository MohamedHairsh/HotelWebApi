using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class RoomSeasonalPrices
    {
        [Key]
        public Guid SeasonalPriceId { get; set; }
        public string? RoomId { get; set; }
        public string? StartDate { get; set; }
        public string? EndDate { get; set; }
        public decimal Price { get; set; }


    }
}
