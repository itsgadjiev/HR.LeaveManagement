using MediatR;

namespace HR.LeaveManagement.Application.Features.LeaveRequest.Queries.GetAllLeaveRequests;

public class GetLeaveRequestListQuery : IRequest<List<LeaveRequestListDto>>
{
}
