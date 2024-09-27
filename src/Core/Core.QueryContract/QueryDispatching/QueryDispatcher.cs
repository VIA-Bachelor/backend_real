using VEA.Core.QueryContracts.Contract;

namespace VEA.Core.QueryContracts.QueryDispatching;

public class QueryDispatcher(IServiceProvider serviceProvider) : IQueryDispatcher
{
    public Task<TAnswer> DispatchAsync<TAnswer>(IQuery<TAnswer> query)
    {
        Type queryInterfaceWithTypes = typeof(IQueryHandler<,>).MakeGenericType(query.GetType(), typeof(TAnswer));
        dynamic handler = serviceProvider.GetService(queryInterfaceWithTypes)!;
        
        if (handler == null)
        {
            throw new QueryHandlerNotFoundException(query.GetType().ToString(), typeof(TAnswer).ToString());
        }
        return handler.HandleAsync((dynamic)query);
    }
    
}

public class QueryHandlerNotFoundException : Exception
{
    public QueryHandlerNotFoundException(string toString, string s)
    {
    }
}