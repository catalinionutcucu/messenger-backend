using MediatR;
using Messenger.Models;

namespace Messenger.Abstractions.Requests.Handlers;

public interface ICommandHandler<TCommand, TResult> : IRequestHandler<TCommand, RequestResult<TResult>>
    where TCommand : ICommand<TResult>;

public interface ICommandHandler<TCommand> : IRequestHandler<TCommand, RequestResult>
    where TCommand : ICommand;
