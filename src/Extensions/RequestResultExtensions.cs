using Messenger.Models;

namespace Messenger.Extensions;

#region value request result

public static partial class RequestResultExtensions
{
    /// <summary>
    /// Converts the request result to an HTTP response of type <see cref = "IResult" /> based on the result state and error type
    /// </summary>
    /// <returns>An HTTP response of type <see cref = "IResult" /></returns>
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
    /// Converts the request result to an HTTP response of type <see cref = "IResult" /> based on the result state and error type
    /// </summary>
    /// <returns>An HTTP response of type <see cref = "IResult" /></returns>
    public static IResult ToHttpResponse(this RequestResult result)
    {
        return result.Map(
            () => Results.Ok(),
            error => error.ToHttpResponse());
    }
}

#endregion
