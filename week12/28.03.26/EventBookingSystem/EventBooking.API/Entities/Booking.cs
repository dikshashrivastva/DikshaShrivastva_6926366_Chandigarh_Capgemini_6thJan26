namespace EventBooking.API.Entities
{
    public class Booking
    {
        public int Id { get; set; }

        // Which event is booked
        public int EventId { get; set; }
        public Event Event { get; set; } = null!;

        // Who booked it
        public int UserId { get; set; }
        public User User { get; set; } = null!;

        public int SeatsBooked { get; set; }

        public DateTime BookedAt { get; set; } = DateTime.UtcNow;

        public string Status { get; set; } = "Confirmed"; // Confirmed or Cancelled

        // Extra: total amount paid
        public decimal TotalAmount { get; set; }
    }
}