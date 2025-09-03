using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationLayer.Dto
{
   public class StaffDto
    {
        public Guid StaffId { get; set; }
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string Address { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Gender { get; set; } = string.Empty;  
        public DateTime JoiningDate { get; set; }

        // File upload (image)
        //public IFormFile? StaffImageFile { get; set; }
        public string StaffImage { get; set; } = string.Empty;
        public IFormFile ?StaffImageFile { get;set; }


    }
}
