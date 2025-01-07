using MediatR;
using Messenger.Models;

namespace Messenger.Abstractions.Requests;

public interface ICommand<TResult> : IRequest<RequestResult<TResult>>;

public interface ICommand : IRequest<RequestResult>;
