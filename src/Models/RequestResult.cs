namespace Messenger.Models;

#region value request result

public sealed class RequestResult<TResult> : Result<TResult, RequestError>
{
    private RequestResult(TResult value) : base(value) { }

    private RequestResult(RequestError error) : base(error) { }

    /// <summary>
    /// Creates a <see cref = "RequestResult{TResult}" /> instance representing a success result
    /// </summary>
    /// <returns>A <see cref = "RequestResult{TResult}" /> instance representing a success result</returns>
    public static new RequestResult<TResult> Success(TResult value)
    {
        return new(value);
    }

    /// <summary>
    /// Creates a <see cref = "RequestResult{TResult}" /> instance representing a failure result
    /// </summary>
    /// <returns>A <see cref = "RequestResult{TResult}" /> instance representing a failure result</returns>
    public static new RequestResult<TResult> Failure(RequestError error)
    {
        return new(error);
    }

    public static implicit operator RequestResult<TResult>(TResult value)
    {
        return Success(value);
    }

    public static implicit operator RequestResult<TResult>(RequestError error)
    {
        return Failure(error);
    }
}

#endregion

#region empty request result

public sealed class RequestResult : Result<RequestError>
{
    private RequestResult() { }

    private RequestResult(RequestError error) : base(error) { }

    /// <summary>
    /// Creates a <see cref = "RequestResult" /> instance representing a success result
    /// </summary>
    /// <returns>A <see cref = "RequestResult" /> instance representing a success result</returns>
    public static new RequestResult Success()
    {
        return new();
    }

    /// <summary>
    /// Creates a <see cref = "RequestResult" /> instance representing a failure result
    /// </summary>
    /// <returns>Af <see cref = "RequestResult" /> instance representing a failure result</returns>
    public static new RequestResult Failure(RequestError error)
    {
        return new(error);
    }

    public static implicit operator RequestResult(RequestError error)
    {
        return Failure(error);
    }
}

#endregion
