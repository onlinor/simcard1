using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class NetworkRepository : INetworkRepository
    {
        private readonly SimCardDBContext _context;

        public NetworkRepository(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<Network> GetByCodeAsync(string code)
        {
            return await _context.Networks.FirstAsync(x => x.Ma == code);
        }
    }
}