using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequests.Requests.Queries
{
    public sealed class GetLeaveRequestList : IRequest<List<LeaveRequestListDto>>
    {
    }
}
