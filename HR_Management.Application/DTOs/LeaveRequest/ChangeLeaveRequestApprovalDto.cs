using HR_Management.Application.DTOs.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveRequest
{
    public class ChangeLeaveRequestApprovalDto: BaseDto
    {
        public bool? Approved { get; set; }
    }
}
