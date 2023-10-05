using System.ComponentModel.DataAnnotations;

namespace HR.LeaveManagement.Application.Exceptions;

public class BadRequestException : Exception
{
    public BadRequestException(string message,ValidationResult validationResult) : base(message)
    {

        

    }

    public IDictionary<string, string[]> ValidationsErrors { get; set; }
}
