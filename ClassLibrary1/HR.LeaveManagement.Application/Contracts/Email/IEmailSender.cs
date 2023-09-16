using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HR.LeaveManagement.Application.Contracts.Email
{
    public interface IEmailSender
    {
        public void SendEmail(string recievers, string subject, string messageText) { }
    }
}
