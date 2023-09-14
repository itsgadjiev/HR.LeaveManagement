using FluentValidation;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.CreateLeaveType;

public class CreateLeaveTypeValidation:AbstractValidator<Domain.LeaveType>
{
	public CreateLeaveTypeValidation()
	{
			RuleFor(x=>x.Name)
			.NotNull()
			.NotEmpty()
			.WithMessage("Invalid Name");
	}
}
