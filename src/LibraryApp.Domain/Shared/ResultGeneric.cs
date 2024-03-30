namespace LibraryApp.Domain.Shared;

public sealed class Result<T>
{
    public T? Value { get; }
    public Error? Error { get; }
    public bool IsSuccess => Error is null;
    public bool IsFailure => !IsSuccess;

    #region private constructors

    private Result(T value)
    {
        Value = value;
        Error = null;
    }
    
    private Result(Error error)
    {
        Value = default;
        Error = error;
    }

    #endregion

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(error);
    }
}