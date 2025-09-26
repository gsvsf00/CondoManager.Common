using CondoManager.Entity.Enums;

namespace CondoManager.Entity.Events
{
    public abstract class DomainEvent
    {
        public Guid Id { get; } = Guid.NewGuid();
        public DateTime OccurredAt { get; } = DateTime.UtcNow;
        public string EventType { get; protected set; } = string.Empty;
    }

    public class UserRegisteredEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public UserRegisteredEvent()
        {
            EventType = "user.registered";
        }
    }

    public class UserUpdatedEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;

        public UserUpdatedEvent()
        {
            EventType = "user.updated";
        }
    }

    public class UserDeletedEvent : DomainEvent
    {
        public Guid UserId { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Phone { get; set; } = string.Empty;

        public UserDeletedEvent()
        {
            EventType = "user.deleted";
        }
    }

    public class CallStartedEvent : DomainEvent
    {
        public Guid CallId { get; set; }
        public Guid CallerId { get; set; }
        public Guid RecipientId { get; set; }
        public CallType CallType { get; set; }
        public DateTime StartedAt { get; set; }

        public CallStartedEvent()
        {
            EventType = "call.started";
        }
    }

    public class CallAcceptedEvent : DomainEvent
    {
        public Guid CallId { get; set; }
        public Guid CallerId { get; set; }
        public Guid RecipientId { get; set; }
        public DateTime AcceptedAt { get; set; }

        public CallAcceptedEvent()
        {
            EventType = "call.accepted";
        }
    }

    public class CallDeclinedEvent : DomainEvent
    {
        public Guid CallId { get; set; }
        public Guid CallerId { get; set; }
        public Guid RecipientId { get; set; }
        public DateTime DeclinedAt { get; set; }

        public CallDeclinedEvent()
        {
            EventType = "call.declined";
        }
    }

    public class CallEndedEvent : DomainEvent
    {
        public Guid CallId { get; set; }
        public Guid CallerId { get; set; }
        public DateTime EndedAt { get; set; }
        public TimeSpan Duration { get; set; }

        public CallEndedEvent()
        {
            EventType = "call.ended";
        }
    }

    public class MessageSentEvent : DomainEvent
    {
        public Guid MessageId { get; set; }
        public Guid SenderId { get; set; }
        public Guid? ApartmentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; }

        public MessageSentEvent()
        {
            EventType = "message.sent";
        }
    }
}