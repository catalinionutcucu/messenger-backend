using Messenger.Models;

namespace Messenger.Extensions;

#region value result

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps the result to a value of type <c>TMap</c> based on the result state
    /// </summary>
    /// <returns>A value of type <c>TMap</c></returns>
    public static TMap Map<TMap, TResult, TError>(this Result<TResult, TError> result, Func<TResult, TMap> success, Func<TError, TMap> failure)
    {
        return result.IsSuccess ? success(result.Value) : failure(result.Error);
    }

    /// <summary>
    /// Maps the result to a value of type <c>TMap</c> based on the result state
    /// </summary>
    /// <returns>A value of type <c>TMap</c></returns>
    public static async Task<TMap> MapAsync<TMap, TResult, TError>(this Result<TResult, TError> result, Func<TResult, Task<TMap>> success, Func<TError, Task<TMap>> failure)
    {
        return result.IsSuccess ? await success(result.Value) : await failure(result.Error);
    }

    /// <summary>
    /// Executes a function based on the result state
    /// </summary>
    public static void Execute<TResult, TError>(this Result<TResult, TError> result, Action<TResult> success, Action<TError> failure)
    {
        if (result.IsSuccess)
        {
            success(result.Value);
        }
        else
        {
            failure(result.Error);
        }
    }

    /// <summary>
    /// Executes an asynchronous function based on the result state
    /// </summary>
    public static async Task ExecuteAsync<TResult, TError>(this Result<TResult, TError> result, Func<TResult, Task> success, Func<TError, Task> failure)
    {
        if (result.IsSuccess)
        {
            await success(result.Value);
        }
        else
        {
            await failure(result.Error);
        }
    }
}

#endregion

#region empty result

public static partial class ResultExtensions
{
    /// <summary>
    /// Maps the result to a value of type <c>TMap</c> based on the result state
    /// </summary>
    /// <returns>A value of type <c>TMap</c></returns>
    public static TMap Map<TMap, TError>(this Result<TError> result, Func<TMap> success, Func<TError, TMap> failure)
    {
        return result.IsSuccess ? success() : failure(result.Error);
    }

    /// <summary>
    /// Maps the result to a value of type <c>TMap</c> based on the result state
    /// </summary>
    /// <returns>A value of type <c>TMap</c></returns>
    public static async Task<TMap> MapAsync<TMap, TError>(this Result<TError> result, Func<Task<TMap>> success, Func<TError, Task<TMap>> failure)
    {
        return result.IsSuccess ? await success() : await failure(result.Error);
    }

    /// <summary>
    /// Executes a function based on the result state
    /// </summary>
    public static void Execute<TError>(this Result<TError> result, Action success, Action<TError> failure)
    {
        if (result.IsSuccess)
        {
            success();
        }
        else
        {
            failure(result.Error);
        }
    }

    /// <summary>
    /// Executes an asynchronous function based on the result state
    /// </summary>
    public static async Task ExecuteAsync<TError>(this Result<TError> result, Func<Task> success, Func<TError, Task> failure)
    {
        if (result.IsSuccess)
        {
            await success();
        }
        else
        {
            await failure(result.Error);
        }
    }
}

#endregion
