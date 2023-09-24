using HR.LeaveManagement.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HR.LeaveManagement.Persistence.Configurations;

public class LeaveTypeConfiguration : IEntityTypeConfiguration<Domain.LeaveType>
{
    public void Configure(EntityTypeBuilder<LeaveType> builder)
    {
        builder.HasData(new LeaveType
        {
            Id=-1,
            CreatedAt = DateTime.UtcNow,
            UpdatedAt= DateTime.UtcNow,
            DefaultDays = 2,
            Name = "Vacation"
        });
    }
}
