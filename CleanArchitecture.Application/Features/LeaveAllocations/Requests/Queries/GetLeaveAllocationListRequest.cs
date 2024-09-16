using CleanArchitecture.Application.DTOs.LeaveAllocation;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Queries
{
    public sealed record GetLeaveAllocationListRequest : IRequest<List<LeaveAllocationListDto>>
    {

    }
}
