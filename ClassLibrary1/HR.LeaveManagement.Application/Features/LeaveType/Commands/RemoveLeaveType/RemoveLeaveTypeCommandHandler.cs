using HR.LeaveManagement.Application.Contracts.Percistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.RemoveLeaveType;

public class RemoveLeaveTypeCommandHandler : IRequestHandler<RemoveLeaveTypeCommand, Unit>
{
    private readonly ILeaveTypeRepository _leaveTypeRepository;

    public RemoveLeaveTypeCommandHandler(ILeaveTypeRepository leaveTypeRepository)
    {
        _leaveTypeRepository = leaveTypeRepository;
    }

    public async Task<Unit> Handle(RemoveLeaveTypeCommand request, CancellationToken cancellationToken)
    {
        var leaveType = await _leaveTypeRepository.GetByIdAsync(request.Id);
        if (leaveType is null)
        {
            throw new Exception("non implemented");
        }

        await _leaveTypeRepository.DeleteAsync(leaveType);

        return Unit.Value;

    }
}
