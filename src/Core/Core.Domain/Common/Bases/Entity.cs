namespace VEA.Core.Domain.Common.Bases;

public class Entity<TId>
{
    public TId Id { get; protected init; }

    protected Entity(TId id)
    {
        Id = id;
    }

    protected Entity() { }
    
    public override bool Equals(object? obj)
    {
        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }
        
        if (ReferenceEquals(this, obj))
        {
            return true;
        }
        
        Entity<TId> other = (Entity<TId>) obj;
        
        return Id != null && Id.Equals(other.Id);
    }

    public override int GetHashCode()
    {
        return Id!.GetHashCode();
    }
    
    public static bool operator ==(Entity<TId>? a, Entity<TId>? b)
    {
        if (a is null && b is null)
        {
            return true;
        }

        if (a is null || b is null)
        {
            return false;
        }

        return a.Equals(b);
    }
    
    public static bool operator !=(Entity<TId>? a, Entity<TId>? b)
    {
        return !(a == b);
    }
}
