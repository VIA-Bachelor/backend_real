using VEA.Core.Domain.Common.Bases;

namespace VEA.Core.Domain.Aggregates;

public abstract class AggregateRoot<TId> : Entity<TId>
{
    public AggregateRoot(TId id) : base(id)
    {
    }

    protected AggregateRoot() {}
}