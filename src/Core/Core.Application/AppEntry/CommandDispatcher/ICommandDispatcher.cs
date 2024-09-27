using VEA.Core.Application.AppEntry.Commands.Common;
using VEA.Core.Tools.OperationResult;

namespace VEA.Core.Application.AppEntry.CommandDispatcher;

public interface ICommandDispatcher
{
    public Task<Result> DispatchAsync<TCommand>(TCommand command) where TCommand : ICommand;
}