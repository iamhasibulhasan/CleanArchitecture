using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;
using CleanArchitecture.Application.Persistence.Contracts.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Queries
{
    public sealed class GetLeaveRequestHandler : IRequestHandler<GetLeaveRequest, LeaveRequestDto>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<LeaveRequestDto> Handle(GetLeaveRequest request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequest(request.Id, cancellationToken);
            return _mapper.Map<LeaveRequestDto>(leaveRequest);
        }
    }
}
