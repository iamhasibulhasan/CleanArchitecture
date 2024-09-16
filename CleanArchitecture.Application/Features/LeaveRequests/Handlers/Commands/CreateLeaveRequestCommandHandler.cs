using AutoMapper;
using CleanArchitecture.Application.Features.LeaveRequests.Requests.Commands;
using CleanArchitecture.Application.Persistence.Contracts.Leave;
using CleanArchitecture.Domain.Entities.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequests.Handlers.Commands
{
    public sealed class CreateLeaveRequestCommandHandler : IRequestHandler<CreateLeaveRequestCommand, int>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public CreateLeaveRequestCommandHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<int> Handle(CreateLeaveRequestCommand request, CancellationToken cancellationToken)
        {
            var leaveRequest = _mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await _leaveRequestRepository.InsertAsync(leaveRequest);

            return leaveRequest.Id;
        }
    }
}
