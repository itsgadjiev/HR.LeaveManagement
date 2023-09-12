﻿using AutoMapper;
using HR.LeaveManagement.Application.Features.LeaveType.Queries.GetLeaveTypeDetails;
using HR.LeaveManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.MappingProfiles;

public class LeaveTypeDetailProfile:Profile
{
	public LeaveTypeDetailProfile()
	{
		CreateMap<LeaveType,LeaveTypeDetailDto>().ReverseMap();
	}
}
