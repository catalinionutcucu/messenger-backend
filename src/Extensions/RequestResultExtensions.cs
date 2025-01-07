using Messenger.Models;

namespace Messenger.Extensions;

#region value request result

public static partial class RequestResultExtensions
{
    /// <summary>
    /// Converts the request result to an HTTP response of type <see cref = "IResult" /> based on whether the result is a success or a failure <br />
    /// Converts success result to <see href = "https://tools.ietf.org/html/rfc7231#section-6.3.1">HTTP response 200</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.RequestInvalid" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.1">HTTP response 400</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.RequestNotAllowed" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.3">HTTP response 403</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.ResourceNotFound" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.4">HTTP response 404</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.ResourceConflict" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.8">HTTP response 409</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.Failure" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.6.1">HTTP response 500</see>
    /// </summary>
    /// <returns>The HTTP response of type <see cref = "IResult" /> based on whether the result is a success or a failure</returns>
    public static IResult ToHttpResponse<TResult>(this RequestResult<TResult> result)
    {
        return result.Map(
            value => Results.Ok(value),
            error => error.ToHttpResponse());
    }
}

#endregion

#region empty request result

public static partial class RequestResultExtensions
{
    /// <summary>
    /// Converts the request result to an HTTP response of type <see cref = "IResult" /> based on whether the result is a success or a failure <br /> <br />
    /// Converts success result to <see href = "https://tools.ietf.org/html/rfc7231#section-6.3.1">HTTP response 200</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.RequestInvalid" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.1">HTTP response 400</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.RequestNotAllowed" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.3">HTTP response 403</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.ResourceNotFound" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.4">HTTP response 404</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.ResourceConflict" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.5.8">HTTP response 409</see> <br />
    /// Converts failure result with error of type <see cref = "RequestErrorType.Failure" /> to <see href = "https://tools.ietf.org/html/rfc7231#section-6.6.1">HTTP response 500</see>
    /// </summary>
    /// <returns>The HTTP response of type <see cref = "IResult" /> based on whether the result is a success or a failure</returns>
    public static IResult ToHttpResponse(this RequestResult result)
    {
        return result.Map(
            () => Results.Ok(),
            error => error.ToHttpResponse());
    }
}

#endregion
