using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries;
using CleanArchitecture.Application.Persistence.Contracts.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Handlers.Queries
{
    public sealed class GetLeaveRequestListHandler : IRequestHandler<GetLeaveRequestList, List<LeaveRequestListDto>>
    {
        private readonly ILeaveRequestRepository _leaveRequestRepository;
        private readonly IMapper _mapper;

        public GetLeaveRequestListHandler(ILeaveRequestRepository leaveRequestRepository, IMapper mapper)
        {
            _leaveRequestRepository = leaveRequestRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveRequestListDto>> Handle(GetLeaveRequestList request, CancellationToken cancellationToken)
        {
            var leaveRequest = await _leaveRequestRepository.GetLeaveRequestList(cancellationToken);
            return _mapper.Map<List<LeaveRequestListDto>>(leaveRequest);
        }
    }
}
