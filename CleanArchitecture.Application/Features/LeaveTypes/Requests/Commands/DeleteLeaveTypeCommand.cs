using MediatR;

namespace CleanArchitecture.Application.Features.LeaveTypes.Requests.Commands
{
    public sealed class DeleteLeaveTypeCommand : IRequest
    {
        public int Id { get; set; }
    }
}
