using System;
using System.Collections.Generic;
using System.Text;
using HR_Management.Application.DTOs;
using HR_Management.Application.DTOs.LeaveRequest;
using MediatR;

namespace HR_Management.Application.Features.LeaveRequests.Requests.Queries
{
    public class GetLeaveRequestsListRequest : IRequest<List<LeaveRequestListDto>>
    {

    }
}
