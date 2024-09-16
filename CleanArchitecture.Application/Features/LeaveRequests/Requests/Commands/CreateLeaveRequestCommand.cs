using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands
{
    public sealed class CreateLeaveRequestCommand : IRequest<int>
    {
        public LeaveRequestDto LeaveRequestDto { get; set; }
    }
}
