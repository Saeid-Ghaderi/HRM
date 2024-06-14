using AutoMapper;
using HR_Management.Application.DTOs.LeaveRequest.Validators;
using HR_Management.Application.DTOs.LeaveType.Validators;
using HR_Management.Application.Exceptions;
using HR_Management.Application.Features.LeaveRequests.Requests.Commands;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.Responses;
using HR_Management_Domain;
using MediatR;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using HR_Management.Application.Contracts.Infrastructure;
using HR_Management.Application.Models;

namespace HR_Management.Application.Features.LeaveRequests.Handlers.Commands
{
    public class CreateLeaveRequestsCommandHandler
        : IRequestHandler<CreateLeaveRequestsCommand, BaseCommandResponse>
    {
        private readonly ILeaveRequestRepository leaveRequestRepository;
        private readonly IMapper mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IEmailSender _emailSender;

        public CreateLeaveRequestsCommandHandler(ILeaveRequestRepository leaveRequestRepository,
            IMapper mapper,ILeaveTypeRepository leaveTypeRepository,
            IEmailSender emailSender)
        {
            this.leaveRequestRepository = leaveRequestRepository;
            this.mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _emailSender = emailSender;
        }
        public async Task<BaseCommandResponse> Handle(CreateLeaveRequestsCommand request, CancellationToken cancellationToken)
        {
            var response = new BaseCommandResponse();
            var validator = new CreateLeaveRequestDtoValidator(_leaveTypeRepository);
            var validationResult = await validator.ValidateAsync(request.LeaveRequestDto);

            if (validationResult.IsValid == false)
            {
                //throw new ValidationException(validationResult);
                response.Success= false;
                response.Message = "Creation Failed";
                response.Errors = validationResult.Errors.Select(q=>q.ErrorMessage).ToList();
            }

            var leaveRequest = mapper.Map<LeaveRequest>(request.LeaveRequestDto);
            leaveRequest = await leaveRequestRepository.Add(leaveRequest);

            response.Success = true;
            response.Message = "Creation Succesdsful";
            response.Id = leaveRequest.Id;

            var email = new Email
            {
                To = "iman@madaeny.com",
                Subject = "Leave Request Submitted",
                Body = $"Your leave request for {request.LeaveRequestDto.StartDate} " +
                $"to {request.LeaveRequestDto.EndDate} " +
                $"has been submitted" 
            };
            try
            {
                await _emailSender.SendEmail(email);
            }catch (Exception ex)
            {
                //log
            }

            return response;
        }
    }
}
