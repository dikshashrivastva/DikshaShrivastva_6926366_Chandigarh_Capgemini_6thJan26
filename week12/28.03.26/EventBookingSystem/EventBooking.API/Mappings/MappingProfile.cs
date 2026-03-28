using AutoMapper;
using EventBooking.API.DTOs;
using EventBooking.API.Entities;

namespace EventBooking.API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            
            CreateMap<Event, EventDto>();

            
            CreateMap<CreateEventDto, Event>()
                .ForMember(dest => dest.AvailableSeats, 
                           opt => opt.MapFrom(src => src.TotalSeats));

            
            CreateMap<Booking, BookingDto>()
                .ForMember(dest => dest.EventTitle,
                           opt => opt.MapFrom(src => src.Event.Title))
                .ForMember(dest => dest.EventLocation,
                           opt => opt.MapFrom(src => src.Event.Location))
                .ForMember(dest => dest.EventDate,
                           opt => opt.MapFrom(src => src.Event.Date));

            
            CreateMap<CreateBookingDto, Booking>();
        }
    }
}