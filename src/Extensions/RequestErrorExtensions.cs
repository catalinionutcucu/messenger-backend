using Messenger.Models;
using Microsoft.AspNetCore.Mvc;

namespace Messenger.Extensions;

public static class RequestErrorExtensions
{
    /// <summary>
    /// Converts the request error to an HTTP response of type <see cref = "IResult" /> based on the error type
    /// </summary>
    /// <returns>An HTTP response of type <see cref = "IResult" /></returns>
    public static IResult ToHttpResponse(this RequestError error)
    {
        return Results.Problem(
            new ProblemDetails
            {
                Status = error.Type switch
                {
                    RequestErrorType.RequestInvalid => 400,
                    RequestErrorType.RequestNotAllowed => 403,
                    RequestErrorType.ResourceNotFound => 404,
                    RequestErrorType.ResourceConflict => 409,
                    _ => 500
                },
                Title = error.Type switch
                {
                    RequestErrorType.RequestInvalid => "Bad Request",
                    RequestErrorType.RequestNotAllowed => "Forbidden",
                    RequestErrorType.ResourceNotFound => "Not Found",
                    RequestErrorType.ResourceConflict => "Conflict",
                    _ => "Internal Server Error"
                },
                Type = error.Type switch
                {
                    RequestErrorType.RequestInvalid => "https://tools.ietf.org/html/rfc7231#section-6.5.1",
                    RequestErrorType.RequestNotAllowed => "https://tools.ietf.org/html/rfc7231#section-6.5.3",
                    RequestErrorType.ResourceNotFound => "https://tools.ietf.org/html/rfc7231#section-6.5.4",
                    RequestErrorType.ResourceConflict => "https://tools.ietf.org/html/rfc7231#section-6.5.8",
                    _ => "https://tools.ietf.org/html/rfc7231#section-6.6.1"
                },
                Extensions = new Dictionary<string, object?>
                {
                    {
                        "error", new Dictionary<string, object?>
                        {
                            { "code", error.Code },
                            { "issues", error.Issues.ToArray() }
                        }
                    }
                }
            });
    }
}
