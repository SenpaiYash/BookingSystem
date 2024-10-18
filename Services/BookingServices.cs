using BookingSystem.Models.Entities;
using BookingSystem.Models;
using BookingSystem.Repositories;
using AutoMapper;
using BookingSystem.External_Services;

namespace BookingSystem.Services
{
    public class BookingService : IBookingService
    {
        private readonly IBookingRepository _bookingRepository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
        private readonly ICalendarSyncService calendarSyncService;

        public BookingService(IBookingRepository bookingRepository,
            IMapper mapper, IConfiguration configuration, ICalendarSyncService calendarSyncService)
        {
            _bookingRepository = bookingRepository;
            _mapper = mapper;
            this._configuration = configuration;
            this.calendarSyncService = calendarSyncService;
        }


        public async Task<BookingModel> GetBookingByIdAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(bookingId);
            if (booking == null)
            {
                return null;
            }
            return _mapper.Map<BookingModel>(booking);  
        }

        public async Task<IEnumerable<BookingModel>> GetAllBookingsAsync()
        {
            var bookings = await _bookingRepository.GetAllBookingsAsync();  
            return _mapper.Map<IEnumerable<BookingModel>>(bookings);
        }

        // Create a new booking (no conversion needed)
        public async Task CreateBookingAsync(BookingModel model)
        {
            var booking = _mapper.Map<Booking>(model);
            await _bookingRepository.CreateBookingAsync(booking);

            bool enableExchange = bool.Parse(_configuration["Synchronization:EnableExchangeSync"]);
            bool enableGoogle = bool.Parse(_configuration["Synchronization:EnableGoogleSync"]);

            if (enableExchange)
            {
                await calendarSyncService.ExchangeCalenderAsync(model);
            }
            if (enableGoogle)
            {
                await calendarSyncService.GoogleCalenderAsync(model);
            }
        }


        public async Task UpdateBookingAsync(BookingModel model)
        {
            var booking = await _bookingRepository.GetBookingByIdAsync(model.Id);
            if (booking != null)
            {
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
            return _mapper.Map<IEnumerable<BookingModel>>(bookings);
        }

        // Get bookings by user and convert to BookingModel
        public async Task<IEnumerable<BookingModel>> GetBookingsByUserAsync(int userId)
        {
            var bookings = await _bookingRepository.GetBookingsByUserAsync(userId);
            return _mapper.Map<IEnumerable<BookingModel>>(bookings);
        }
    }

}
