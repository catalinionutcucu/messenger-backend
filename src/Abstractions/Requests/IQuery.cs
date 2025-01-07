using MediatR;
using Messenger.Models;

namespace Messenger.Abstractions.Requests;

public interface IQuery<TResult> : IRequest<RequestResult<TResult>>;
