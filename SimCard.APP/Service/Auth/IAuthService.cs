using System.Threading.Tasks;

using SimCard.APP.Models;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
{
    public interface IAuthService
    {
        Task<AuthResultViewModel> Authenticate(LoginViewModel loginViewModel);
    }
}
