using CleanArchitecture.Application.Common.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Abstraction.MediatR;

public interface IQueryResult<TResponse> : IRequest<Result<TResponse>>
{
}

public interface IQuery<out TResponse> : IRequest<TResponse>
{
}
