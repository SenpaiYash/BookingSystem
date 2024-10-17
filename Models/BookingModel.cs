namespace BookingSystem.Models
{
    public record BookingModel
    {
        public int Id { get; set; }
        public int RoomID { get; set; }
        public int UserID { get; set; }
        public DateTime BookingDate { get; set; }
        public TimeOnly StartTime { get; set; }
        public TimeOnly EndTime { get; set; }
        
        public string? RoomName { get; set; }
        public string? UserName { get; set; }
    }
}
