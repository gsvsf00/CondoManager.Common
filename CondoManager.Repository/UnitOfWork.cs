using CondoManager.Repository.Interfaces;
using CondoManager.Repository.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace CondoManager.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DbContext _context;
        private IDbContextTransaction? _transaction;
        
        private IUserRepository? _users;
        private IApartmentRepository? _apartments;
        private IMessageRepository? _messages;
        private ICallRepository? _calls;
        private IEventRepository? _events;
        private IConversationRepository? _conversations;
        private IConversationParticipantRepository? _conversationParticipants;
        private ICallParticipantRepository? _callParticipants;

        public UnitOfWork(DbContext context)
        {
            _context = context;
        }

        public IUserRepository Users => _users ??= new UserRepository(_context);
        public IApartmentRepository Apartments => _apartments ??= new ApartmentRepository(_context);
        public IMessageRepository Messages => _messages ??= new MessageRepository(_context);
        public ICallRepository Calls => _calls ??= new CallRepository(_context);
        public IEventRepository Events => _events ??= new EventRepository(_context);
        public IConversationRepository Conversations => _conversations ??= new ConversationRepository(_context);
        public IConversationParticipantRepository ConversationParticipants => _conversationParticipants ??= new ConversationParticipantRepository(_context);
        public ICallParticipantRepository CallParticipants => _callParticipants ??= new CallParticipantRepository(_context);

        public async Task<int> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public async Task BeginTransactionAsync()
        {
            _transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task CommitTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.CommitAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public async Task RollbackTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _context.Dispose();
        }
    }
}