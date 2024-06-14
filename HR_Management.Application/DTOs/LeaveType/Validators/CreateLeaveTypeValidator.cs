using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace HR_Management.Application.DTOs.LeaveType.Validators
{
    public class CreateLeaveTypeValidator:AbstractValidator<CreateLeaveTypeDto>
    {
        public CreateLeaveTypeValidator()
        {
            Include(new ILeaveTypeDtoValidator());
        }
    }
}
