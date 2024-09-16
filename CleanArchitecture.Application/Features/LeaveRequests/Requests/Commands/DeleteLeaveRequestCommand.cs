using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands
{
    public sealed class DeleteLeaveRequestCommand : IRequest
    {
        public int Id { get; set; }
    }
}
