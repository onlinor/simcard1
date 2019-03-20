using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public interface INetworkRepository
    {
        Task<IEnumerable<Network>> GetNetworks();
        Task<Network> AddNetwork(Network Nw);
        void UpdateNetwork(Network Nw);
        void RemoveNetwork(Network Nw);
        //Task<bool> IsProductExists(Product pr);     
    }
}