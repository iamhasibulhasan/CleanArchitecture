using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Requests.Commands
{
    public sealed class DeleteLeaveAllocationCommand : IRequest
    {
        public int Id { get; set; }
    }
}
