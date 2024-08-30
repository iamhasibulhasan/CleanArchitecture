using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Leave
{
    public sealed class LeaveType : BaseEntity
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
    }
}
