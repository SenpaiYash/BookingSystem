using BookingSystem.Models.Entities;
using BookingSystem.Models;
using BookingSystem.Repositories;
using AutoMapper;

namespace BookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;

        public BookingService(IBookingRepository bookingRepository,IMapper mapper)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
        }

        // Get a booking by ID and convert it to BookingModel
        public async Task<BookingModel> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);
            if (booking == null)
            {
                return null;
            }

            return _mapper.Map<BookingModel>(booking);
        }

        // Create a new booking (no conversion needed)
        public async Task CreateBookingAsync(BookingModel model)
        {
            var booking = _mapper.Map<Booking>(model);
            await _bookingRepository.CreateBookingAsync(booking);
        }

        // Update an existing booking
        public async Task UpdateBookingAsync(BookingModel model)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(model.BookingID);
            if (booking != null)
            {
                // Use AutoMapper to map BookingModel to Booking
                _mapper.Map(model, booking);
                await _bookingRepository.UpdateBookingAsync(booking);
            }
        }

        // Delete a booking by ID
        public async Task DeleteBookingAsync(int bookingId)
        {
            await _bookingRepository.DeleteBookingAsync(bookingId);
        }

        // Get bookings by room and convert to BookingModel
        public async Task<IEnumerable<BookingModel>> GetBookingsByRoomAsync(int roomId)
        {
            var bookings = await _bookingRepository.GetBookingsByRoomAsync(roomId);
            // Use AutoMapper to map List<Booking> to List<BookingModel>
            return _mapper.Map<IEnumerable<BookingModel>>(bookings);
        }

        // Get bookings by user and convert to BookingModel
        public async Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserAsync(userId);
            // Use AutoMapper to map List<Booking> to List<BookingModel>
            return _mapper.Map<IEnumerable<BookingModel>>(bookings);
        }
    }

}
