using AutoMapper;
using EventBooking.API.Data;
using EventBooking.API.DTOs;
using EventBooking.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize] // ALL endpoints here need login
    public class BookingsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public BookingsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        
        private int GetUserId() =>
            int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier)!);

        
        [HttpGet]
        public async Task<IActionResult> GetMyBookings()
        {
            var userId = GetUserId();

            var bookings = await _db.Bookings
                .Include(b => b.Event) // bring event details too
                .Where(b => b.UserId == userId)
                .OrderByDescending(b => b.BookedAt)
                .ToListAsync();

            return Ok(_mapper.Map<List<BookingDto>>(bookings));
        }

        
        [HttpPost]
        public async Task<IActionResult> BookTicket(CreateBookingDto dto)
        {
            var userId = GetUserId();

            
            var ev = await _db.Events.FindAsync(dto.EventId);
            if (ev == null)
                return NotFound("Event not found.");

            
            if (ev.AvailableSeats < dto.SeatsBooked)
                return BadRequest($"Only {ev.AvailableSeats} seats available.");

           
            if (ev.Date <= DateTime.UtcNow)
                return BadRequest("Cannot book tickets for past events.");

            
            var booking = new Booking
            {
                EventId = dto.EventId,
                UserId = userId,
                SeatsBooked = dto.SeatsBooked,
                TotalAmount = ev.TicketPrice * dto.SeatsBooked,
                Status = "Confirmed"
            };

            
            ev.AvailableSeats -= dto.SeatsBooked;

            _db.Bookings.Add(booking);
            await _db.SaveChangesAsync();

            
            var result = await _db.Bookings
                .Include(b => b.Event)
                .FirstAsync(b => b.Id == booking.Id);

            return Ok(_mapper.Map<BookingDto>(result));
        }

        
        [HttpDelete("{id}")]
        public async Task<IActionResult> CancelBooking(int id)
        {
            var userId = GetUserId();

            var booking = await _db.Bookings
                .Include(b => b.Event)
                .FirstOrDefaultAsync(b => b.Id == id && b.UserId == userId);

            if (booking == null)
                return NotFound("Booking not found.");

            if (booking.Status == "Cancelled")
                return BadRequest("Booking is already cancelled.");

           
            booking.Event.AvailableSeats += booking.SeatsBooked;
            booking.Status = "Cancelled";

            await _db.SaveChangesAsync();

            return Ok("Booking cancelled successfully.");
        }
    }
}