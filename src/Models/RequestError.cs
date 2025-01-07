using System.Collections.Immutable;

namespace Messenger.Models;

public sealed class RequestError
{
    public RequestErrorType Type { get; }

    public string Code { get; }

    public ImmutableList<string> Issues { get; }

    private RequestError(RequestErrorType type, string code, params IEnumerable<string> issues)
    {
        Type = type;
        Code = code;
        Issues = [ ..issues ];
    }

    /// <summary>
    /// Creates a <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.RequestInvalid" /> representing a request invalid error
    /// </summary>
    /// <returns>A <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.RequestInvalid" /> representing a request invalid error</returns>
    public static RequestError RequestInvalid(string code, params IEnumerable<string> issues)
    {
        return new(RequestErrorType.RequestInvalid, code, issues);
    }

    /// <summary>
    /// Creates a <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.RequestNotAllowed" /> representing a request not allowed error
    /// </summary>
    /// <returns>A <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.RequestNotAllowed" /> representing a request not allowed error</returns>
    public static RequestError RequestNotAllowed(string code, params IEnumerable<string> issues)
    {
        return new(RequestErrorType.RequestNotAllowed, code, issues);
    }

    /// <summary>
    /// Creates a <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.ResourceNotFound" /> representing a resource not found error
    /// </summary>
    /// <returns>A <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.ResourceNotFound" /> representing a resource not found error</returns>
    public static RequestError ResourceNotFound(string code, params IEnumerable<string> issues)
    {
        return new(RequestErrorType.ResourceNotFound, code, issues);
    }

    /// <summary>
    /// Creates a <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.ResourceConflict" /> representing a resource conflict error
    /// </summary>
    /// <returns>A <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.ResourceConflict" /> representing a resource conflict error</returns>
    public static RequestError ResourceConflict(string code, params IEnumerable<string> issues)
    {
        return new(RequestErrorType.ResourceConflict, code, issues);
    }

    /// <summary>
    /// Creates a <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.Failure" /> representing a failure error
    /// </summary>
    /// <returns>A <see cref = "RequestError" /> instance of type <see cref = "RequestErrorType.Failure" /> representing a failure error</returns>
    public static RequestError Failure(string code, params IEnumerable<string> issues)
    {
        return new(RequestErrorType.Failure, code, issues);
    }
}

public enum RequestErrorType
{
    RequestInvalid = 400,
    RequestNotAllowed = 403,
    ResourceNotFound = 404,
    ResourceConflict = 409,
    Failure = 500
}
