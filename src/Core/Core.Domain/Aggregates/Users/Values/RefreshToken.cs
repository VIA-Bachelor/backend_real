using VEA.Core.Domain.Common.Bases;
using VEA.Core.Tools.OperationResult;

namespace Core.Domain.Aggregates.Users.Values;

public class RefreshToken : ValueObject
{
    public string Value { get; }
    
    private RefreshToken(string value)
    {
        Value = value;
    }
    
    public static Result<RefreshToken> Create(string value)
    {
        var validation = Result.Validator()
            .Validate();
        
        
        return validation.IsFailure
            ? Result.Failure<RefreshToken>(validation.Errors)
            : Result.Success(new RefreshToken(value));
    }
    
    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}