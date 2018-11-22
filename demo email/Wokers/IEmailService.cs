using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace demo_email.Wokers
{
    public interface IEmailService
    {
        Task<bool> SendUserEmails();
    }
}
