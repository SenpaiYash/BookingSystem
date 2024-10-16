using AutoMapper;
using BookingSystem.Models.Entities;
using BookingSystem.Models;

namespace BookingSystem.Mapping
{
    public class BookingProfile : Profile
    {
        public BookingProfile()
        {
            // Map from BookingModel to Booking (for creating or updating a booking)
            CreateMap<BookingModel, Booking>();

            // Map from Booking to BookingModel (for displaying booking data in views)
            CreateMap<Booking, BookingModel>()
                .ForMember(dest => dest.RoomName, opt => opt.MapFrom(src => src.Room.RoomName))
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName));
        }
    }
}
