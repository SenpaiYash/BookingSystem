using BookingSystem.External_Services;
using BookingSystem.Repositories;
using BookingSystem.Services;
using System.Configuration;

namespace BookingSystem
{
    public static class ServiceCollectionBuilder
    {
        public static IServiceCollection AddServices(this IServiceCollection services)
        {

            //External Services
             services.AddScoped<ICalendarSyncService, CalendarSyncService>();        


            // Register Repositories
            services.AddScoped<IBookingRepository, BookingRepository>();
            // Register Services
            services.AddScoped<IBookingService, BookingService>();


            return services;

        }
    }
}
