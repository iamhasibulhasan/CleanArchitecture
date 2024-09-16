using AutoMapper;
using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Application.Features.LeaveAllocations.Requests.Queries;
using CleanArchitecture.Application.Persistence.Contracts.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocations.Handlers.Queries
{
    public sealed class GetLeaveAllocationListRequestHandler : IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationListDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository, IMapper mapper)
        {
            _leaveAllocationRepository = leaveAllocationRepository;
            _mapper = mapper;
        }
        public async Task<List<LeaveAllocationListDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetLeaveAllocationList(cancellationToken);
            return _mapper.Map<List<LeaveAllocationListDto>>(leaveAllocations);
        }
    }
}
