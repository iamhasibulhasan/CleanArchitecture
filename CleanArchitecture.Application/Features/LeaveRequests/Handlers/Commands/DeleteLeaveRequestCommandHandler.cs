using CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands;
using CleanArchitecture.Application.Persistence.Contracts.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequests.Handlers.Commands
{
    public sealed class DeleteLeaveRequestCommandHandler : IRequestHandler<DeleteLeaveRequestCommand>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;

        public DeleteLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository)
        {
            _leaveRequestRepository = leaveRequestRepository;
        }
        public async Task<Unit> Handle(DeleteLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var delete = await _leaveRequestRepository.GetAsync(request.Id);
            await _leaveRequestRepository.DeleteAsync(delete);
            return Unit.Value;
        }
    }
}
