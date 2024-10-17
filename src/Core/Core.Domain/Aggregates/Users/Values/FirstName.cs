using VEA.Core.Domain.Common.Bases;
using VEA.Core.Tools.OperationResult;

namespace Core.Domain.Aggregates.Users.Values;

public class FirstName : ValueObject
{
    public string Value { get; }

    private FirstName(string value)
    {
        Value = value;
    }
    
    public static Result<FirstName> Create(string value)
    {
        var validation = Result.Validator()
            .Assert(value.Length >= 2 && value.Length <= 25, Errors.FirstNameLengthNotValid())
            .Assert(value.All(char.IsLetter), Errors.FirstNameCannotContainNumbers())
            .Assert(value.All(char.IsLetterOrDigit), Errors.FirstNameCannotContainSymbols())
            .Validate();
        return validation.IsFailure
            ? Result.Failure<FirstName>(validation.Errors)
            : Result.Success(new FirstName(value));
    }

    public static class Errors
    {
        public static Error FirstNameLengthNotValid() => 
            new(ErrorType.InvalidArgument, 1, "First name is not valid, must be between 2 and 25 characters.");

        public static Error FirstNameCannotContainNumbers() => 
            new(ErrorType.InvalidArgument, 2, "First name cannot contain numbers.");

        public static Error FirstNameCannotContainSymbols() => 
            new(ErrorType.InvalidArgument, 3, "First name cannot contain symbols.");
    }

    protected override IEnumerable<object> GetEqualityComponents()
    {
        yield return Value;
    }
}