using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.RemoveLeaveType;

public class RemoveLeaveTypeCommand : IRequest<Unit>
{
    public int Id { get; set; }
}
