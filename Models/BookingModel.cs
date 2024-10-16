namespace BookingSystem.Models
{
    public record BookingModel
    {
        public int BookingID { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }

        // Optional: You can also include related info for display in the view
        public string RoomName { get; set; }
        public string UserName { get; set; }
    }
}
