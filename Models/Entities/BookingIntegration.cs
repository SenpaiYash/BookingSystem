namespace BookingSystem.Models.Entities
{
    public class BookingIntegration : BaseEntity
    {
        public int BookingID { get; set; }
        public Booking Booking { get; set; }
        public int IntegrationTypeID { get; set; }
        public IntegrationType IntegrationType { get; set; }
        public bool IsSynced { get; set; }
        public DateTime? LastSyncedDate { get; set; }
    }
}
