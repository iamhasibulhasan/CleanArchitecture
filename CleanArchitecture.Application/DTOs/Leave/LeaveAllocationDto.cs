using CleanArchitecture.Application.DTOs.Common;

namespace CleanArchitecture.Application.DTOs.Leave
{
    public sealed class LeaveAllocationDto : BaseDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public LeaveTypeDto LeaveType { get; set; }
    }
}
