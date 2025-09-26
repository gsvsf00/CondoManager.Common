namespace CondoManager.Entity.Enums
{
    [Flags] // Allows combining roles (Resident + Trustee)
    public enum UserRole
    {
        None = 0,
        Resident = 1,
        Trustee = 2,
        Gatekeeper = 3,
        Admin = 4
    }
}
