namespace BookingSystem.Models.Entities
{
    public class IntegrationType : BaseEntity
    {
        public string Name { get; set; } // Exchange, Google, etc.
        public ICollection<RoomIntegration> RoomIntegrations { get; set; }
        public ICollection<BookingIntegration> BookingIntegrations { get; set; }
    }
}
