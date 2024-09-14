using CleanArchitecture.Application.DTOs.Common;
using CleanArchitecture.Application.DTOs.Leave;

namespace CleanArchitecture.Application.DTOs.LeaveAllocation
{
    public sealed class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
    }
}
