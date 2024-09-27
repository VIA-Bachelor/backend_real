using VEA.Core.Domain.Aggregates;
using VEA.Core.Domain.Common.Bases;
using VEA.Core.Tools.OperationResult;

namespace Core.Domain.Aggregates;

public interface IGenericRepository<TAggr, TId>
    where TAggr : AggregateRoot<TId>
    where TId : ValueObject
{
    Task<Result<TAggr>> GetAsync(TId id);
    Task<Result> RemoveAsync(TId id);
    Task<Result<TId>> AddAsync(TAggr aggregate);
}