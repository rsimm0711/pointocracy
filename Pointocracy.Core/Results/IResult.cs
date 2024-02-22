using System.Diagnostics.CodeAnalysis;

namespace Pointocracy.Core.Results;

public interface IResult
{
    [MemberNotNullWhen(false, nameof(ErrorMessage))]
    bool IsSuccess { get; }
    string? ErrorMessage { get; }
}

public struct Result: IResult
{
    public bool IsSuccess { get; }
    public string? ErrorMessage { get; }
    public Exception? Exception { get; }

    private Result(bool isSuccess, string? errorMessage, Exception? exception)
    {
        IsSuccess = isSuccess;
        ErrorMessage = errorMessage;
        Exception = exception;
    }

    public static Result Success() => new(true, null, null);
    public static Result Failure(string errorMessage, Exception exception) => new(false, errorMessage, exception);
}

public record struct Result<T>( bool IsSuccess, T? Obj, string? ErrorMessage): IResult
{
    [MemberNotNullWhen(true, nameof(Obj))]
    public bool IsSuccess { get; } = IsSuccess;
}