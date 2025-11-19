namespace CondoManager.Entity.Enums
{
    public enum ChatType
    {
        Direct = 1,              // User to User private chat
        ApartmentGroup = 2,      // Apartment residents group chat
        GatekeeperBroadcast = 3  // Gatekeeper to apartment (one-way initially)
    }
}