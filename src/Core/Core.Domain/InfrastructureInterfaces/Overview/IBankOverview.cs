using VEA.Core.Tools.OperationResult;

namespace Core.Domain.InfrastructureInterfaces.Overview;

public interface IBankOverview
{
    public Task<Result<AccessToken>> GetAccessToken(string code);
}

public record AccessToken(string Token, string RefreshToken); // Will be converted to a class when we move past prototypes.