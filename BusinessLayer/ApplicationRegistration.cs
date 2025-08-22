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
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IBookingRepository, BookingRepository>();
            services.AddScoped<IRoomRepository, RoomRepository>();
            services.AddScoped<IAmenitiesRepository, AmenitiesRepository>();
            services.AddScoped<IStaffRepository, StaffRepository>();

            return services;
        }
    }
}