using System.ComponentModel.DataAnnotations;
using EventBooking.API.Validations;

namespace EventBooking.API.Entities
{
    public class Event
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Event title is required")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [FutureDate]
        public DateTime Date { get; set; }

        public string Location { get; set; } = string.Empty;

        public int TotalSeats { get; set; }

        public int AvailableSeats { get; set; }

        public decimal TicketPrice { get; set; }

        // Extra fields we added
        public string Category { get; set; } = string.Empty;   // Music, Tech, Sports
        public string ImageUrl { get; set; } = string.Empty;   // Banner image
        public bool IsActive { get; set; } = true;

        // One event can have many bookings
        public ICollection<Booking> Bookings { get; set; } = new List<Booking>();
    }
}