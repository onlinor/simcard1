using System.Threading.Tasks;

using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
{
    public interface IUserService
    {
        Task<bool> Create(UserViewModel userViewModel);
    }
}
