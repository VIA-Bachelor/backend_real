namespace VEA.Core.Application.AppEntry.CommandDispatcher;

public class ServiceNotFoundException : Exception
{
    public ServiceNotFoundException(string message) : base(message)
    {
    }
}