using AutoMapper;
using EventBooking.API.Data;
using EventBooking.API.DTOs;
using EventBooking.API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventBooking.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EventsController : ControllerBase
    {
        private readonly AppDbContext _db;
        private readonly IMapper _mapper;

        public EventsController(AppDbContext db, IMapper mapper)
        {
            _db = db;
            _mapper = mapper;
        }

        
        [HttpGet]
        public async Task<IActionResult> GetAllEvents()
        {
            var events = await _db.Events
                .Where(e => e.IsActive)
                .OrderBy(e => e.Date)
                .ToListAsync();

            var eventDtos = _mapper.Map<List<EventDto>>(events);
            return Ok(eventDtos);
        }

        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEvent(int id)
        {
            var ev = await _db.Events.FindAsync(id);

            if (ev == null)
                return NotFound("Event not found.");

            return Ok(_mapper.Map<EventDto>(ev));
        }

        
        [HttpPost]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> CreateEvent(CreateEventDto dto)
        {
            var ev = _mapper.Map<Event>(dto);
            _db.Events.Add(ev);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEvent), 
                new { id = ev.Id }, _mapper.Map<EventDto>(ev));
        }

        
        [HttpDelete("{id}")]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var ev = await _db.Events.FindAsync(id);

            if (ev == null)
                return NotFound("Event not found.");

            
            ev.IsActive = false;
            await _db.SaveChangesAsync();

            return Ok("Event deleted successfully.");
        }
    }
}