using VEA.Core.Domain.Common.Bases;
using VEA.Core.Tools.OperationResult;

namespace Core.Domain.Aggregates.Users.Values;

public class AccessToken : ValueObject
{
    public string Value { get; }
    
    private AccessToken(string value)
    {
        Value = value;
    }
    
    public static Result<AccessToken> Create(string value)
    {
        var validation = Result.Validator()
            .Validate();
        
        
        return validation.IsFailure
            ? Result.Failure<AccessToken>(validation.Errors)
            : Result.Success(new AccessToken(value));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}