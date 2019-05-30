
using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Services
{
    public interface INetworkRangeService
    {
        Task<IEnumerable<NetworkRangeViewModel>> GetAll();

        Task<NetworkRangeViewModel> GetById(int id);

        Task<bool> Create(NetworkRangeViewModel networkViewModels);

        Task<bool> Update(NetworkRangeViewModel networkViewModel);

        Task<bool> Remove(int id);
    }
}
