using MediatR;
using Messenger.Models;

namespace Messenger.Abstractions.Requests.Handlers;

public interface IQueryHandler<TQuery, TResult> : IRequestHandler<TQuery, RequestResult<TResult>>
    where TQuery : IQuery<TResult>;
