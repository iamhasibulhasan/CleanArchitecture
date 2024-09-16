using CleanArchitecture.Application.DTOs.LeaveRequest;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveRequest.Requests.Queries
{
    public sealed class GetLeaveRequest : IRequest<LeaveRequestDto>
    {
        public int Id { get; set; }
    }
}
