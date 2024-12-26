using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Education.Queries.GetAll;

public sealed record GetAllEducationQuery() : IQuery<Result>;
public sealed class GetAllEducationQueryHandler : IQueryHandler<GetAllEducationQuery, Result>
{
    private readonly IEducationService _educationService;

    public GetAllEducationQueryHandler(IEducationService educationService)
    {
        _educationService = educationService;
    }

    public async Task<Result> Handle(GetAllEducationQuery request, CancellationToken cancellationToken)
    {
        return await _educationService.GetAll(cancellationToken);
    }
}
