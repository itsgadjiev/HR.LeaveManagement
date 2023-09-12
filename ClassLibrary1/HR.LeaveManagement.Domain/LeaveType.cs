using HR.LeaveManagement.Domain.Common.abstracts;
using HR.LeaveManagement.Domain.Common.concrets;

namespace HR.LeaveManagement.Domain
{
    public class LeaveType : BaseEntity, IAuditable
    {
        public string Name { get; set; }
        public int DefaultDays { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}