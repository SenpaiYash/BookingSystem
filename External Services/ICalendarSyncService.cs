using BookingSystem.Models;

namespace BookingSystem.External_Services
{
    public interface ICalendarSyncService
    {
        Task GoogleCalenderAsync(BookingModel booking);
        Task ExchangeCalenderAsync(BookingModel booking);
    }
}
