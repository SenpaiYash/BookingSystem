namespace BookingSystem.Models.Entities
{
    public class Booking : BaseEntity
    {
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public int UserID { get; set; }
        public User User { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        public ICollection<BookingIntegration> BookingIntegrations { get; set; }
    }
}
