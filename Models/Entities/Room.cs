namespace BookingSystem.Models.Entities
{
    public class Room : BaseEntity
    {
        public string RoomName { get; set; }
        public int Capacity { get; set; }
        public ICollection<Booking> Bookings { get; set; }
        
    }
}
