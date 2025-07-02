using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ApplicationLayer.Dto;
using ApplicationLayer.Models;
using AutoMapper;

namespace ApplicationLayer.Common
{
    public class ApplicationMapper : Profile
    {

        public ApplicationMapper()
        {
             CreateMap<HotelImages , HotelImageInsertDto>().ReverseMap();
        }
    }
}
