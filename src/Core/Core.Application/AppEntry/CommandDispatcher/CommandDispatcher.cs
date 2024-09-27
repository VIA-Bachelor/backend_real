using VEA.Core.Application.AppEntry.Commands.Common;
using VEA.Core.Tools.OperationResult;

namespace VEA.Core.Application.AppEntry.CommandDispatcher;

public class CommandDispatcher(IServiceProvider serviceProvider) : ICommandDispatcher
{
    public Task<Result> DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
        => GetService<ICommandHandler<TCommand>>()
            .Handle(command);
    
    private T GetService<T>()
        => (T) serviceProvider.GetService(typeof(T))! ?? 
           throw new ServiceNotFoundException($"Service of type {typeof(T).Name} not found.");
}