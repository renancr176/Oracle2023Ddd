using System.Runtime.Serialization;

namespace Oracle2023Ddd.Domain.Core.Messages;

public abstract class Message
{
    [IgnoreDataMember]
    public string MessageType { get; protected set; }
    [IgnoreDataMember]
    public Guid? AggregateId { get; set; }

    protected Message()
    {
        MessageType = GetType().Name;
    }
}