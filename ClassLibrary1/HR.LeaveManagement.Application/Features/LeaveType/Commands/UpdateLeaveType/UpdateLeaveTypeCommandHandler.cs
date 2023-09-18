using AutoMapper;
using HR.LeaveManagement.Application.Contracts.Logging;
using HR.LeaveManagement.Application.Contracts.Percistance;
using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveType.Commands.UpdateLeaveType
{
    public class UpdateLeaveTypeCommandHandler : IRequestHandler<UpdateLeaveTypeCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly IAppLogger<UpdateLeaveTypeCommand> _appLogger;

        public UpdateLeaveTypeCommandHandler(IMapper mapper,ILeaveTypeRepository leaveTypeRepository,IAppLogger<UpdateLeaveTypeCommand> appLogger)
        {
            _mapper = mapper;
            _leaveTypeRepository = leaveTypeRepository;
            _appLogger = appLogger;
        }
        public async Task<Unit> Handle(UpdateLeaveTypeCommand request, CancellationToken cancellationToken)
        {
            var validator=new UpdateLeaveTypeValidator(_leaveTypeRepository);
            var validationResult=await validator.ValidateAsync(request);

            if (validationResult.Errors.Any())
            {
                _appLogger.LogWarning("Validtaion errors for {0} - {1}", nameof(LeaveType), request.Id);
            }

            var leaveTypeToUpdate = _mapper.Map<Domain.LeaveType>(request);
            await _leaveTypeRepository.UpdateAsync(leaveTypeToUpdate);

            return Unit.Value;
        }
    }
}
