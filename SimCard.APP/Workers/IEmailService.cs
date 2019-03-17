using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace SimCard.APP.Workers
{
    public interface IEmailService
    {
        Task<bool> SendUserEmails();
    }
}
