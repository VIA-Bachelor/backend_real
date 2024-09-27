using VEA.Core.Application.AppEntry.Commands.Common;
using VEA.Core.Tools.OperationResult;

namespace VEA.Core.Application.AppEntry;

public interface ICommandHandler<in TCommand, TResult> where TCommand : ICommand
{
    Task<Result<TResult>> Handle(TCommand command);
}

public interface ICommandHandler<in TCommand> where TCommand : ICommand
{
    Task<Result> Handle(TCommand command);
}