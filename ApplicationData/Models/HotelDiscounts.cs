using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class HotelDiscounts
    {

        [Key]

        public Guid DiscountId { get; set; }

        public string? HotelId { get; set; }

        public string ?Title {  get; set; }

        public string  ?Description { get; set; }
        public double DiscountPercentage { get; set; }
        
    public DateTime? ValidFrom { get; set; }

    public DateTime? ValidTo { get; set; }


    }
}
