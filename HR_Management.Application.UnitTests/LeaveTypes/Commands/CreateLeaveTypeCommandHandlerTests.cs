using AutoMapper;
using FluentValidation.TestHelper;
using HR_Management.Application.Contracts.Persistence;
using HR_Management.Application.DTOs.LeaveType;
using HR_Management.Application.Features.LeaveTypes.Handlers.Commands;
using HR_Management.Application.Features.LeaveTypes.Requests.Commands;
using HR_Management.Application.Profiles;
using HR_Management.Application.Responses;
using HR_Management.Application.UnitTests.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR_Management.Application.UnitTests.LeaveTypes.Commands
{
    public class CreateLeaveTypeCommandHandlerTests
    {
        IMapper _mapper;
        Mock<ILeaveTypeRepository> _mockRepository;
        CreateLeaveTypeDto _leaveTypeDto;
        public CreateLeaveTypeCommandHandlerTests()
        {
            _mockRepository = MockLeaveRepository.GetLeaveTypeRepository();

            var mapperConfig = new MapperConfiguration(m =>
            {
                m.AddProfile<MappingProfile>();
            });

            _mapper = mapperConfig.CreateMapper();

            _leaveTypeDto = new CreateLeaveTypeDto()
            {
                DefaultDay = 15,
                Name = "Test DTO"
            };
        }

        [Fact]
        public async Task CreateLeaveType()
        {
            var handler = new CreateLeaveTypeCommandHandler(_mockRepository.Object, _mapper);
            var result = await handler.Handle(new CreateLeaveTypeCommand()
            {
                LeaveTypeDto = _leaveTypeDto
            }, CancellationToken.None);

            result.ShouldBeOfType<BaseCommandResponse>();

            var leaveTypes = await _mockRepository.Object.GetAll();

            leaveTypes.Count.ShouldBe(3);
        }

     
    }
}
