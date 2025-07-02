using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessLayer.AuthServices;
using BusinessLayer.IRepository;
using BusinessLayer.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace BusinessLayer
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {

            services.AddAutoMapper(typeof(ApplicationRegistration));
            services.AddScoped<IHotelRepository, HotelRepository>();
            services.AddScoped<IHotelImagesRepository, HotelImagesRepository>();
            services.AddScoped<IHotelRoomsRepository, HotelRoomsRepository>();
            services.AddScoped<IHotelPoliciesRopository, HotelPoliciesRopository>();
            services.AddScoped<IHotelFacilitiesRepository, HotelFacilitiesRepository>();
            services.AddScoped<IRoomFacilitiesRepository, RoomFacilitiesRepository>();
            services.AddScoped<IRoomSeasonalPricesRepository, RoomSeasonalPricesRepository>();
            services.AddScoped<IRoomAvailabilityRepository, RoomAvailabilityRepository>();
            services.AddScoped<IHotelNearbyLandmarks, HotelNearbyLandmarksRepository>();
            services.AddScoped<IHotelDiscountRepository, HotelDiscountRepository>();
            services.AddScoped<IFacilitiesRepository, FacilitiesRepository>();
            services.AddScoped<IAuthService, AuthService>();


            return services;
        }
    }
}