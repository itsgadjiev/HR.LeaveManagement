using HR.LeaveManagement.Application.Contracts.Percistance;
using HR.LeaveManagement.Domain;
using HR.LeaveManagement.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class LeaveAllocationRepository : GenericRepository<LeaveAllocation>, ILeaveAllocationRepository
{
    public LeaveAllocationRepository(AppDbContext appDbContext) : base(appDbContext)
    {

    }

    public async Task AddAllocations(List<LeaveAllocation> allocations)
    {
        await _appDbContext.AddRangeAsync(allocations);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<bool> AllocationExists(string userId, int leaveTypeId, int period)
    {
        return await _appDbContext.LeaveAllocations.AnyAsync(q => q.EmployeeId == userId
                                    && q.LeaveTypeId == leaveTypeId
                                    && q.Period == period);
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails()
    {
        var leaveAllocations = await _appDbContext.LeaveAllocations
           .Include(q => q.LeaveType)
           .ToListAsync();
        return leaveAllocations;
    }

    public async Task<List<LeaveAllocation>> GetLeaveAllocationsWithDetails(string userId)
    {
        var leaveAllocations = await _appDbContext.LeaveAllocations.Where(q => q.EmployeeId == userId)
           .Include(q => q.LeaveType)
           .ToListAsync();
        return leaveAllocations;
    }

    public async Task<LeaveAllocation> GetLeaveAllocationWithDetails(int id)
    {
        var leaveAllocation = await _appDbContext.LeaveAllocations
            .Include(q => q.LeaveType)
            .FirstOrDefaultAsync(q => q.Id == id);

        return leaveAllocation;
    }

    public async Task<LeaveAllocation> GetUserAllocations(string userId, int leaveTypeId)
    {
        return await _appDbContext.LeaveAllocations.FirstOrDefaultAsync(q => q.EmployeeId == userId
                                    && q.LeaveTypeId == leaveTypeId);
    }
}


