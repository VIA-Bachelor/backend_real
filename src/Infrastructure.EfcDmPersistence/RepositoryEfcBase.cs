using Core.Domain.Aggregates;
using Infrastructure.EfcDmPersistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using VEA.Core.Domain.Aggregates;
using VEA.Core.Domain.Common.Bases;
using VEA.Core.Tools.OperationResult;
using VEA.Infrastructure.EfcDmPersistence.UnitOfWork;

namespace VEA.Infrastructure.EfcDmPersistence;

public class RepositoryEfcBase<TAggr, TId>(DomainModelContext context) :
    EfcUnitOfWork(context),
    IGenericRepository<TAggr, TId> 
    where TAggr : AggregateRoot<TId>
    where TId : ValueObject
{
    public async Task<Result<TAggr>> GetAsync(TId id)
    {
        var aggregate = await context.Set<TAggr>().SingleAsync(x => x.Id == id);
        return Result.Success(aggregate);
    }

    public async Task<Result> RemoveAsync(TId id)
    {
        await context.Set<TAggr>().Where((t) => t.Id == id).ExecuteDeleteAsync();
        await SaveChangesAsync();
        return Result.Success();
    }

    public async Task<Result<TId>> AddAsync(TAggr aggregate)
    {
        EntityEntry<TAggr> result = await context.Set<TAggr>().AddAsync(aggregate);
        await SaveChangesAsync();
        return Result.Success(result.Entity.Id);
    }
}