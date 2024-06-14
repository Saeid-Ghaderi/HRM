using HR_Management.Application.DTOs.Common;
using HR_Management.Application.DTOs.LeaveType;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class LeaveRequestListDto : BaseDto
    {
        public LeaveTypeDto LeaveType { get; set; }
        public DateTime DateRequested { get; set; }
        public bool? Aoorived { get; set; }
    }
}
