namespace BookingSystem.Models.Entities
{
    public class RoomIntegration : BaseEntity
    {
        public int RoomID { get; set; }
        public Room Room { get; set; }
        public int IntegrationTypeID { get; set; }
        public IntegrationType IntegrationType { get; set; }
        public string ExternalCalendarID { get; set; } // External ID for Google/Exchange calendar.
    }
}
