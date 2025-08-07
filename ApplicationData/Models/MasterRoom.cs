using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Models
{
    public class MasterRoom
    {
        [Key]
        public Guid RoomID { get; set; }
        public string RoomType { get; set; }
    }

}
