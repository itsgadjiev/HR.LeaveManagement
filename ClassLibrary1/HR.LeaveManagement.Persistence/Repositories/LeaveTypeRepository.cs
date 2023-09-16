using HR.LeaveManagement.Application.Contracts.Percistance;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveTypeRepository : GenericRepository<LeaveType>, ILeaveTypeRepository
{
    public LeaveTypeRepository(AppDbContext appDbContext) : base(appDbContext)
    {
    }
    public async Task<bool> IsLeaveTypeUnique(string name)
    {
        return await _appDbContext.LeaveTypes.AnyAsync(q => q.Name == name);
    }
}


