using CleanArchitecture.Application.DTOs.Leave;
using MediatR;

namespace CleanArchitecture.Application.Features.LeaveType.Requests.Queries
{
    public class GetLeaveTypeDetailRequest : IRequest<LeaveTypeDto>
    {
        public int Id { get; set; }
    }
}
