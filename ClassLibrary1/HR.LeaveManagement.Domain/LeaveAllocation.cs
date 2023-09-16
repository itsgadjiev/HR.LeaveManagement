using HR.LeaveManagement.Domain.Common.abstracts;
using HR.LeaveManagement.Domain.Common.concrets;

namespace HR.LeaveManagement.Domain;

public class LeaveAllocation : BaseEntity, IAuditable
{
    public int NumberOfDays { get; set; }
    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }
    public int Period { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }
    public string EmployeeId { get; set; }
    
}
