using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Users.Queries.GetAll
{
    public sealed record GetAllUserQuery() : IQuery<Result>;
    public sealed class GetAllUserQueryHandler : IQueryHandler<GetAllUserQuery, Result>
    {
        private readonly IUserService _userService;
        public GetAllUserQueryHandler(IUserService userService)
        {
            _userService = userService;
        }
        public async Task<Result> Handle(GetAllUserQuery request, CancellationToken cancellationToken)
        {
            return await _userService.GetAll(cancellationToken);
        }
    }
}
