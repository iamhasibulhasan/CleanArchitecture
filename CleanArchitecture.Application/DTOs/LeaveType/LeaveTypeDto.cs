using CleanArchitecture.Application.DTOs.Common;

namespace CleanArchitecture.Application.DTOs.Leave
{
    public sealed class LeaveTypeDto : BaseDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
