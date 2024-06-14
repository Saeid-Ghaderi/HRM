using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Features.LeaveAllocations.Requests.Queries;
using HR_Management.Application.DTOs.LeaveAllocation;
using HR_Management.Application.Persistence.Contracts;

namespace HR_Management.Application.Features.LeaveAllocations.Handlers.Queries
{
    public class GetLeaveAllocationListRequestHandler :
        IRequestHandler<GetLeaveAllocationListRequest, List<LeaveAllocationDto>>
    {
        private readonly ILeaveAllocationRepository _leaveAllocationRepository;
        private readonly IMapper _mapper;

        //public GetLeaveAllocationListRequestHandler(ILeaveAllocationRepository leaveAllocationRepository
        //    , IMapper mapper)
        //{
        //    _leaveAllocationRepository = leaveAllocationRepository;
        //    _mapper = mapper;
        //}

        public async Task<List<LeaveAllocationDto>> Handle(GetLeaveAllocationListRequest request, CancellationToken cancellationToken)
        {
            var leaveAllocations = await _leaveAllocationRepository.GetAll();
            return _mapper.Map<List<LeaveAllocationDto>>(leaveAllocations);
        }
    }
}
