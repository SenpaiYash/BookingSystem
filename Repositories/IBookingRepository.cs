using BookingSystem.Models.Entities;

namespace BookingSystem.Repositories
{
    public interface IBookingRepository
    {
        Task<List<Booking>> GetAllBookingsAsync();
        Task<Booking> GetBookingByIdAsync(int bookingId);
        Task<Booking> CreateBookingAsync(Booking booking);
        Task UpdateBookingAsync(Booking booking);
        Task DeleteBookingAsync(int bookingId);
        Task<List<Booking>> GetBookingsByRoomAsync(int roomId);
        Task<List<Booking>> GetBookingsByUserAsync(int userId);
    }
}
