using CleanArchitecture.Application.DTOs.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands
{
    public sealed class CreateLeaveTypeCommand : IRequest<int>
    {
        public LeaveTypeDto LeaveTypeDto { get; set; }
    }
}
