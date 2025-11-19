using CondoManager.Repository.Interfaces;

namespace CondoManager.Repository.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IUserRepository Users { get; }
        IApartmentRepository Apartments { get; }
        IMessageRepository Messages { get; }
        ICallRepository Calls { get; }
        IEventRepository Events { get; }
        
        // New repositories for chat functionality
        IConversationRepository Conversations { get; }
        IConversationParticipantRepository ConversationParticipants { get; }
        ICallParticipantRepository CallParticipants { get; }
        
        Task<int> SaveChangesAsync();
        Task BeginTransactionAsync();
        Task CommitTransactionAsync();
        Task RollbackTransactionAsync();
    }
}