using CleanArchitecture.Application.DTOs.LeaveAllocation;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands
{
    public sealed class CreateLeaveAllocationCommand : IRequest<int>
    {
        public CreateLeaveAllocationDto LeaveAllocationDto { get; set; }
    }
}
