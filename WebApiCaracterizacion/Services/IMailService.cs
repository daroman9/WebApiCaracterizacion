using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApiCaracterizacion.Services
{
    public interface IMailService
    {
        Task SendEmail(string email, string subject, string htmlContent);
    }
}
