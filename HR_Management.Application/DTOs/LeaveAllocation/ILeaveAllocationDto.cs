using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveAllocation
{
    public interface ILeaveAllocationDto
    {
        public int NumberOfDays { get; set; }
        public int LeaveTypeId { get; set; }
        public int Priod { get; set; }
    }
}
