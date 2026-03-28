using System.ComponentModel.DataAnnotations;
using EventBooking.API.Validations;

namespace EventBooking.API.DTOs
{
    // What we SEND to frontend (showing events)
    public class EventDto
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public string Location { get; set; } = string.Empty;
        public int AvailableSeats { get; set; }
        public decimal TicketPrice { get; set; }
        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }

    // What we RECEIVE from frontend (creating event)
    public class CreateEventDto
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        [FutureDate]
        public DateTime Date { get; set; }

        [Required]
        public string Location { get; set; } = string.Empty;

        [Range(1, 10000, ErrorMessage = "Seats must be between 1 and 10000")]
        public int TotalSeats { get; set; }

        [Range(0, 100000)]
        public decimal TicketPrice { get; set; }

        public string Category { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
    }
}