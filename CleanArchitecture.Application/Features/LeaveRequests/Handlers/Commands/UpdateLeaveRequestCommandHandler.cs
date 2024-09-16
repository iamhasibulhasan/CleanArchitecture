using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands;
using CleanArchitecture.Application.Persistence.Contracts.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequests.Handlers.Commands
{
    public sealed class UpdateLeaveRequestCommandHandler : IRequestHandler<UpdateLeaveRequestCommand, Unit>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public UpdateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(UpdateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var existingData = await _leaveRequestRepository.GetAsync(request.Id);
            if (request.LeaveRequestDto is not null)
            {
                _mapper.Map(request.LeaveRequestDto, existingData);
                await _leaveRequestRepository.UpdateAsync(existingData);
            }
            else if (request.ChangeLeaveRequestApprovalDto is not null)
            {
                await _leaveRequestRepository.ChangeApprovalStatus(existingData, request.ChangeLeaveRequestApprovalDto.Approved, cancellationToken);
            }
            return Unit.Value;
        }
    }
}
