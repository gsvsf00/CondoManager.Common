using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Models
{
    public class User
    {
        public int Id { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string? Email { get; set; }

        public string? Phone { get; set; }

        public string PasswordHash { get; set; } = string.Empty;

        public UserRole Roles { get; set; }

        public string? AuthToken { get; set; }

        public DateTime? LastLoginAt { get; set; }

        public ApartmentUser? Apartment { get; set; }

        public DateTime CreatedAt { get; set; }

        public DateTime UpdatedAt { get; set; }
    }
}
