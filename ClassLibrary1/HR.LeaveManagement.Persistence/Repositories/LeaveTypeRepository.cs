using HR.LeaveManagement.Application.Contracts.Percistance;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Database;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
}


