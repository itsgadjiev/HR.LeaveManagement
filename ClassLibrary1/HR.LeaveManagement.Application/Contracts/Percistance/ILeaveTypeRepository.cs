﻿using HR.LeaveManagement.Domain;

namespace HR.LeaveManagement.Application.Contracts.Percistance;

public interface ILeaveTypeRepository : IGenericRepository<LeaveType>
{
    Task<bool> IsLeaveTypeUnique(string name);

}