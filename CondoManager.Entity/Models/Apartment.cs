namespace CondoManager.Entity.Models
{
    public class Apartment
    {
        public int Id { get; set; }

        public string Number { get; set; } = string.Empty;

        // Relation: many users per apartment
        public ICollection<ApartmentUser> Residents { get; set; } = new List<ApartmentUser>();
    }
}
