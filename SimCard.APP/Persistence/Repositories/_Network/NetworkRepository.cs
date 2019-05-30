using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Models;

namespace SimCard.APP.Persistence.Repositories
{
    public class NetworkRepository : INetworkRepository
    {
        private readonly SimCardDBContext _context;

        public NetworkRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<Network> AddNetwork(Network Nw)
        {
            if (await IsNetworkExists(Nw))
            {
                return Nw;
            }
            await _context.Networks.AddAsync(Nw);

            return Nw;
        }
        public async Task<IEnumerable<Network>> GetNetworks()
        {
            return await _context.Networks.ToListAsync();
        }

        public async Task<bool> IsNetworkExists(Network Nw)
        {
            if (await _context.Networks.AnyAsync(x => x.Id == Nw.Id))
            {
                return true;
            }

            return false;
        }

        public void RemoveNetwork(Network Network)
        {
            _context.Networks.Remove(Network);
        }

        public void UpdateNetwork(Network pr)
        {
            throw new System.NotImplementedException();
        }
    }
}