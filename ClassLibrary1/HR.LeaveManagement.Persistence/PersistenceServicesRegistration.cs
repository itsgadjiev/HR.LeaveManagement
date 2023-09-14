using HR.LeaveManagement.Application.Contracts.Percistance;
using HR.LeaveManagement.Persistence.Database;
using HR.LeaveManagement.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace HR.LeaveManagement.Persistence;

public static class PersistenceServicesRegistration
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services,IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("default"));
        });

        services
            .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
            .AddScoped<ILeaveTypeRepository,LeaveTypeRepository>()
            .AddScoped<ILeaveRequestRepository , LeaveRequestRepository>()
            .AddScoped<ILeaveAllocationRepository , LeaveAllocationRepository>();
        

        return services;
    }
}