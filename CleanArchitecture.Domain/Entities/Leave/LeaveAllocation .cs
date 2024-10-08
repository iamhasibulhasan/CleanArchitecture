﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Domain.Entities.Leave
{
    public sealed class LeaveAllocation : BaseEntity
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Period { get; set; }
        public LeaveType LeaveType { get; set; }
    }
}
