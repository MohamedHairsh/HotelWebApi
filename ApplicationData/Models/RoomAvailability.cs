using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class RoomAvailability
    {
        [Key]
        public Guid RoomId {  get; set; }
        public DateTime Date {  get; set; }
        public int AvailableCount { get; set; }
    }
}
