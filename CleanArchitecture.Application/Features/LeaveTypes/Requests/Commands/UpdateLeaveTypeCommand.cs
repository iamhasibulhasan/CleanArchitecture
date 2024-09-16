using CleanArchitecture.Application.DTOs.LeaveType;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands
{
    public sealed class UpdateLeaveTypeCommand : IRequest<Unit>
    {
        public UpdateLeaveTypeDto LeaveTypeDto { get; set; }
    }
}
