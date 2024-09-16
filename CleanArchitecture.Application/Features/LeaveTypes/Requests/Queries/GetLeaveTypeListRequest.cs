using CleanArchitecture.Application.DTOs.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Queries
{
    public class GetLeaveTypeListRequest : IRequest<List<LeaveTypeDto>>
    {
    }
}
