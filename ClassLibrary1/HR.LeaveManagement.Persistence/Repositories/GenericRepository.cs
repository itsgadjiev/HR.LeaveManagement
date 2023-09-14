using HR.LeaveManagement.Application.Contracts.Percistance;
using HR.LeaveManagement.Domain.Common.concrets;
using HR.LeaveManagement.Persistence.Database;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Persistence.Repositories;

public class GenericRepository<T> : IGenericRepository<T> where T : BaseEntity
{
    protected readonly AppDbContext _appDbContext;

    public GenericRepository(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task AddAsync(T entity)
    {
        await _appDbContext.AddAsync(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(T entity)
    {
        _appDbContext.Remove(entity);
        await _appDbContext.SaveChangesAsync();
    }

    public async Task<List<T>> GetAllAsync()
    {
        return await _appDbContext.Set<T>().AsNoTracking().ToListAsync();
    }

    public async Task<T> GetByIdAsync(int id)
    {
        return await _appDbContext.Set<T>().AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == id);
    }

    public async Task UpdateAsync(T entity)
    {
        _appDbContext.Update(entity);
        _appDbContext.Entry(entity).State = EntityState.Modified;
        await _appDbContext.SaveChangesAsync();
    }
}
