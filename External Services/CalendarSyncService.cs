using BookingSystem.Models;
using Google.Apis.Calendar.v3;
using Microsoft.Graph;

namespace BookingSystem.External_Services
{
    public class CalendarSyncService : ICalendarSyncService
    {
        private readonly GraphServiceClient _graphClient;
        private readonly CalendarService _calendarService;

        public CalendarSyncService(GraphServiceClient graphService,CalendarService calendarService) 
        { 
            _graphClient = graphService;
            _calendarService = calendarService;
        }
        public Task ExchangeCalenderAsync(BookingModel booking)
        {   

            return Task.CompletedTask;
        }

        public Task GoogleCalenderAsync(BookingModel booking)
        {
            return Task.CompletedTask;
        }
    }
}
