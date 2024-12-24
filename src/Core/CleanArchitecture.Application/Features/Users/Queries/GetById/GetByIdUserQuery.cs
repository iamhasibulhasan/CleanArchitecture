using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Users.Queries.GetById
{
    public sealed record GetByIdUserQuery(int id) : IQuery<Result>;
    public sealed class GetByIdUserQueryHandler : IQueryHandler<GetByIdUserQuery, Result>
    {
        private readonly IUserService _userService;
        public GetByIdUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Result> Handle(GetByIdUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetById(request.id, cancellationToken);
        }
    }
}
