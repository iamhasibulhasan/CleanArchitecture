using CleanArchitecture.Application.DTOs.LeaveAllocation;
using CleanArchitecture.Domain.Entities.Leave;

namespace CleanArchitecture.Application.Persistence.Contracts.Leave
{
    public interface ILeaveAllocationRepository : IGenericRepository<LeaveAllocation>
    {
        #region Queries
        Task<LeaveAllocationDto> GetLeaveAllocationWithDetails(int id, CancellationToken cancellationToken = default);
        Task<List<LeaveAllocationListDto>> GetLeaveAllocationList(CancellationToken cancellationToken = default);
        #endregion
    }
}
