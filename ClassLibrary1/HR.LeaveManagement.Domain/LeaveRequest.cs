using HR.LeaveManagement.Domain.Common.abstracts;
using HR.LeaveManagement.Domain.Common.concrets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Domain;

public class LeaveRequest:BaseEntity,IAuditable
{
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }

    public LeaveType LeaveType { get; set; }
    public int LeaveTypeId { get; set; }

    public DateTime DateRequested { get; set; }
    public string RequestComments { get; set; }

    public bool? Approved { get; set; }
    public bool Cancelled { get; set; }

    public string RequestingEmployeeId { get; set; }
    public DateTime CreatedAt { get; set; }
    public DateTime UpdatedAt { get; set; }

}
