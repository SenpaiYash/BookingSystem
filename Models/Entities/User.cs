namespace BookingSystem.Models.Entities
{
    public class User : BaseEntity
    {
        public string UserName { get; set; }
        public ICollection<Booking> Bookings { get; set; }
    }
}
