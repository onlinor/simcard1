using System.Threading.Tasks;

namespace SimCard.APP.Workers
{
    public interface IEmailService
    {
        Task<bool> SendUserEmails();
    }
}
