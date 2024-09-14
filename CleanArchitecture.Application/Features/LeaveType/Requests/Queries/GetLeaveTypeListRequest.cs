using CleanArchitecture.Application.DTOs.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveType.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
