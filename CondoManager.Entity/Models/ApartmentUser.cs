namespace CondoManager.Entity.Models
{
    public class ApartmentUser
    {
        public Guid ApartmentId { get; set; }
        public Apartment Apartment { get; set; } = null!;

        public Guid UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
