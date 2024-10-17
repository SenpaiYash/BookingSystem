namespace BookingSystem.Models.Entities
{
    public class IntegrationType : BaseEntity
    {
        public string Name { get; set; } 
        public ICollection<BookingIntegration> BookingIntegrations { get; set; }
    }
}
