using BookingSystem.Models;

namespace BookingSystem.External_Services
{
    public class CalendarSyncService : ICalendarSyncService
    {
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
