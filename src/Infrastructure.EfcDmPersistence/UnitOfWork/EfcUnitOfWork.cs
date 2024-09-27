using Infrastructure.EfcDmPersistence;
using Microsoft.EntityFrameworkCore;
using VEA.Core.Domain.Common.UnitOfWork;

namespace VEA.Infrastructure.EfcDmPersistence.UnitOfWork;

public class EfcUnitOfWork(DomainModelContext context) : IUnitOfWork
{
    public Task SaveChangesAsync() => context.SaveChangesAsync();
}