using Rte2023Ddd.Domain.Core.Messages;

namespace Rte2023Ddd.Domain.Core.DomainObjects;

public abstract class Entity
{
    public Guid Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }
    public DateTime? UpdatedAt { get; set; }
    public DateTime? DeletedAt { get; set; }
    public string CreatorProgram { get; set; }
    public int CreatorUser { get; set; }
    public string? UpdateProgram { get; set; }
    public int? UpdateUser { get; set; }
    public string? UserBdd { get; set; }
    public int? SysRevisa { get; set; }

    private List<Event> _notifications;
    public IReadOnlyCollection<Event> Notifications => _notifications?.AsReadOnly();

    protected Entity()
    {
        Id = Guid.NewGuid();
        CreatedAt = DateTime.UtcNow;
        UserBdd = "DDD";
        SysRevisa = 99999;
    }

    protected Entity(Guid id)
        : this()
    {
        Id = id;
    }

    public void AddEvent(Event evento)
    {
        _notifications = _notifications ?? new List<Event>();
        _notifications.Add(evento);
    }

    public void RemoveEvent(Event eventItem)
    {
        _notifications?.Remove(eventItem);
    }

    public void ClearEvents()
    {
        _notifications?.Clear();
    }

    public override bool Equals(object obj)
    {
        var compareTo = obj as Entity;

        if (ReferenceEquals(this, compareTo)) return true;
        if (ReferenceEquals(null, compareTo)) return false;

        return Id.Equals(compareTo.Id);
    }

    public static bool operator ==(Entity a, Entity b)
    {
        if (ReferenceEquals(a, null) && ReferenceEquals(b, null))
            return true;

        if (ReferenceEquals(a, null) || ReferenceEquals(b, null))
            return false;

        return a.Equals(b);
    }

    public static bool operator !=(Entity a, Entity b)
    {
        return !(a == b);
    }

    public override int GetHashCode()
    {
        return (GetType().GetHashCode() * 907) + Id.GetHashCode();
    }

    public override string ToString()
    {
        return GetType().Name + "[Id = " + Id + "]";
    }
}

public abstract class EntityAutoIncrementId : Entity
{
    public new int Id { get; protected set; }
}

public abstract class EntityStringId : Entity
{
    public new string Id { get; protected set; }

    public EntityStringId(string id)
    {
        Id = id;
    }
}