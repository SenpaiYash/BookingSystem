using BookingSystem.Models;
using BookingSystem.Models.Entities;

namespace BookingSystem.Services
{
    public interface IBookingService
    {
        Task<BookingModel> GetBookingByIdAsync(int bookingId);
        Task CreateBookingAsync(BookingModel model);
        Task UpdateBookingAsync(BookingModel model);
        Task DeleteBookingAsync(int bookingId);
        Task<IEnumerable<BookingModel>> GetBookingsByRoomAsync(int roomId);
        Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(int userId);

    }
}
