using CleanArchitecture.Application.DTOs.LeaveAllocation;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveAllocation.Requests.Queries
{
    public sealed class GetLeaveAllocationRequest : IRequest<LeaveAllocationDto>
    {
        public int Id { get; set; }
    }
}
