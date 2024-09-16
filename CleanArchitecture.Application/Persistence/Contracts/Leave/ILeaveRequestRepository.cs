using CleanArchitecture.Application.DTOs.LeaveRequest;
using CleanArchitecture.Domain.Entities.Leave;

namespace CleanArchitecture.Application.Persistence.Contracts.Leave
{
    public interface ILeaveRequestRepository : IGenericRepository<LeaveRequest>
    {
        Task<LeaveRequestDto> GetLeaveRequest(int id, CancellationToken cancellationToken = default);
        Task<List<LeaveRequestListDto>> GetLeaveRequestList(CancellationToken cancellationToken = default);
    }
}
