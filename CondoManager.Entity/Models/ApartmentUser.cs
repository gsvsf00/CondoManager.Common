namespace CondoManager.Entity.Models
{
    public class ApartmentUser
    {
        public int ApartmentId { get; set; }
        public Apartment Apartment { get; set; } = null!;

        public int UserId { get; set; }
        public User User { get; set; } = null!;
    }
}
