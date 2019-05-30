using System.Threading.Tasks;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Services
{
    public interface IAuthService
    {
        Task<AuthResultViewModel> Authenticate(LoginViewModel loginViewModel);
    }
}
