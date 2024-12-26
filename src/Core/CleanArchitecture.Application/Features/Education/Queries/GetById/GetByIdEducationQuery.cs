using CleanArchitecture.Application.Abstraction.MediatR;
using CleanArchitecture.Application.Common.Utilities;
using CleanArchitecture.Application.ServiceInterfaces.Users;

namespace CleanArchitecture.Application.Features.Education.Queries.GetById;

public sealed record GetByIdEducationQuery(int id) : IQuery<Result>;
public sealed class GetByIdEducationQueryHandler : IQueryHandler<GetByIdEducationQuery, Result>
{
    private readonly IEducationService _educationService;

    public GetByIdEducationQueryHandler(IEducationService educationService)
    {
        _educationService = educationService;
    }

    public async Task<Result> Handle(GetByIdEducationQuery request, CancellationToken cancellationToken)
    {
        return await _educationService.GetById(request.id, cancellationToken);
    }
}
