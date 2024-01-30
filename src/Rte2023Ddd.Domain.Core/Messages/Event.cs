using MediatR;

namespace Oracle2023Ddd.Domain.Core.Messages;

public abstract class Event : Message, INotification
{
    public DateTime Timestamp { get; private set; }

    protected Event()
    {
        Timestamp = DateTime.UtcNow;
    }
}