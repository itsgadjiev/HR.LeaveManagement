using HR.LeaveManagement.Application.Contracts.Percistance;
using HR.LeaveManagement.Domain;
using Moq;

namespace HR.LeaveManagement.Application.UnitTests.Features.LeaveType;

public class MockLeaveTypeRepository
{
    public static Mock<ILeaveTypeRepository> GetLeaveTypeMockRepository()
    {
        var leaveTypes = new List<Domain.LeaveType>()
        {
            new Domain.LeaveType
            {
                Id = 1,
                Name = "Foo",
                DefaultDays = 1,
            },
            new Domain.LeaveType
            {
                Id = 2,
                Name = "Boo",
                DefaultDays = 30,
            },
            new Domain.LeaveType
            {
                Id = 3,
                Name = "Doo",
                DefaultDays = 13,
            },
        };

        var mockRepo = new Mock<ILeaveTypeRepository>();

        mockRepo.Setup(r => r.GetAllAsync()).ReturnsAsync(leaveTypes);

        mockRepo.Setup(r => r.AddAsync(It.IsAny<Domain.LeaveType>()))
            .Returns((Domain.LeaveType leaveType) =>
            {
                leaveTypes.Add(leaveType);
                return Task.CompletedTask;
            });

        return mockRepo;
    }
}
