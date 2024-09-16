namespace CleanArchitecture.Application.DTOs.LeaveType
{
    public sealed class CreateLeaveTypeDto
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
