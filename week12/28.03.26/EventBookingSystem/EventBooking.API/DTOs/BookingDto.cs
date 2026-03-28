using System.ComponentModel.DataAnnotations;

namespace EventBooking.API.DTOs
{
    // What we RECEIVE when user wants to book
    public class CreateBookingDto
    {
        [Required]
        public int EventId { get; set; }

        [Range(1, 10, ErrorMessage = "You can book between 1 and 10 seats only")]
        public int SeatsBooked { get; set; }
    }

    // What we SEND back to show booking details
    public class BookingDto
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string EventTitle { get; set; } = string.Empty;
        public string EventLocation { get; set; } = string.Empty;
        public DateTime EventDate { get; set; }
        public int SeatsBooked { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookedAt { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}