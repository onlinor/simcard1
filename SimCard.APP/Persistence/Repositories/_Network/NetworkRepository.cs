using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories._Network
{    
    public class NetworkRepository : INetworkRepository
    {
        private readonly SimCardDBContext context;       

        public NetworkRepository(SimCardDBContext context)
        {
            this.context = context;
        }

        public async Task<Network> AddNetwork(Network Nw)
        {
            if(await IsNetworkExists(Nw))
            {
                return Nw;
            }
            await context.Networks.AddAsync(Nw);

            return Nw;           
        }
        public async Task<IEnumerable<Network>> GetNetworks()
        {
            return await context.Networks.ToListAsync();
        }

        public async Task<bool> IsNetworkExists(Network Nw)
        {
            if (await context.Networks.AnyAsync(x => x.Ma == Nw.Ma))
                return true;
            return false;
        }

        public void RemoveNetwork(Network Network)
        {
            context.Networks.Remove(Network);
        }

        public void UpdateNetwork(Network pr)
        {
            throw new System.NotImplementedException();
        }
    }
}