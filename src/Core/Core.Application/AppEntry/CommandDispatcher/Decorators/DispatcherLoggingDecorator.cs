using VEA.Core.Application.AppEntry.Commands.Common;
using VEA.Core.Tools.OperationResult;

namespace VEA.Core.Application.AppEntry.CommandDispatcher.Decorators;

public class DispatcherLoggingDecorator(ICommandDispatcher next) : ICommandDispatcher
{
    public List<string> Logs { get; } = [];

    public Task<Result> DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand
    {
        string format = $"Command of type {command.GetType().Name} dispatched.";
        Logs.Add(format);
        Console.WriteLine(format);
        return next.DispatchAsync(command);
    }
}