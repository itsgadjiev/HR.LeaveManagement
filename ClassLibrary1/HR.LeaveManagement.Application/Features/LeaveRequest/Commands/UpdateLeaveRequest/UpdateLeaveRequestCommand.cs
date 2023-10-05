using HR.LeaveManagement.Application.Features.LeaveRequest.Common;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Commands.UpdateLeaveRequest;

public class UpdateLeaveRequestCommand : BaseLeaveRequest, IRequest<Unit>
{
    public int Id { get; set; }
    public string RequestComments { get; set; } 
    public bool Cancelled { get; set; }
}
