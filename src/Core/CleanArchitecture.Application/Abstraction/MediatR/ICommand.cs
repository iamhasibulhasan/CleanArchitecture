using CleanArchitecture.Application.Common.Utilities;
using MediatR;

namespace CleanArchitecture.Application.Abstraction.MediatR;


public interface ICommand : IRequest<Result>
{
}

public interface ICommand<TResponse> : IRequest<Result<TResponse>>
{
}
