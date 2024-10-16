using BookingSystem.Data;
using BookingSystem.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace BookingSystem.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly BookingContext _context;

        public BookingRepository(BookingContext context)
        {
            _context = context;
        }
        
        public async Task<Booking> GetBookingByIdAsync(int bookingId)
        {
            return await _context.Bookings
                                 .Include(b => b.Room) 
                                 .Include(b => b.User)  
                                 .FirstOrDefaultAsync(b => b.Id == bookingId);
        }

        public async Task<Booking> CreateBookingAsync(Booking booking)
        {
            _context.Bookings.Add(booking);
            await _context.SaveChangesAsync();
            return booking;
        }

        public async Task UpdateBookingAsync(Booking booking)
        {
            _context.Bookings.Update(booking);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _context.Bookings.FindAsync(bookingId);
            if (booking != null)
            {
                _context.Bookings.Remove(booking);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<List<Booking>> GetBookingsByRoomAsync(int roomId)
        {
            return await _context.Bookings
                                 .Include(b => b.Room)
                                 .Include(b => b.User)
                                 .Where(b => b.RoomID == roomId)
                                 .ToListAsync();
        }


        public async Task<List<Booking>> GetBookingsByUserAsync(int userId)
        {
            return await _context.Bookings
                                 .Include(b => b.Room)
                                 .Include(b => b.User)
                                 .Where(b => b.UserID == userId)
                                 .ToListAsync();
        }
    }

}
