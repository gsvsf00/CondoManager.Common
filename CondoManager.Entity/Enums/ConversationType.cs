namespace CondoManager.Entity.Enums
{
    public enum ConversationType
    {
        Direct = 1,              // One-on-one conversation
        ApartmentGroup = 2,      // Group chat for apartment residents
        GatekeeperBroadcast = 3, // Gatekeeper broadcasting to apartment
        Announcement = 4         // System/Admin announcements
    }
}