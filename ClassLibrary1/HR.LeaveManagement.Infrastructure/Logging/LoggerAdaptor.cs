using HR.LeaveManagement.Application.Contracts.Logging;
using Microsoft.Extensions.Logging;

namespace HR.LeaveManagement.Infrastructure.Logging;

public class LoggerAdaptor<T> : IAppLogger<T>
{
    private readonly ILoggerFactory _logger;

    public LoggerAdaptor(ILoggerFactory logger)
    {
        _logger = logger;
    }
    public void LogInformation(string message, params object[] args)
    {
        _logger.CreateLogger<T>().LogInformation(message, args);
    }

    public void LogWarning(string message, params object[] args)
    {
       _logger.CreateLogger<T>().LogWarning(message, args); 
    }
}
