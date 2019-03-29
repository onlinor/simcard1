using SimCard.APP.Models;
using SimCard.APP.ViewModels;

using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public interface IAuthService
    {
        Task<UserViewModel> Authenticate(LoginViewModel loginViewModel);
    }
}
