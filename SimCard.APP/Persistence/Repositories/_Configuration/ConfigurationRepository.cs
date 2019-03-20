using Microsoft.EntityFrameworkCore;

using SimCard.API.Models;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
{
    public class ConfigurationRepository : IConfigurationRepository
    {
        private readonly SimCardDBContext _context;

        public ConfigurationRepository(SimCardDBContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Configuration>> GetAllConfiguration()
        {
            return await _context.Configurations.ToListAsync();
        }

        public async Task<Configuration> GetConfiguration(int id)
        {
            return await _context.Configurations.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Configuration> UpdateConfiguration(int id, Configuration configuration)
        {
            Configuration configurationUpdate = _context.Configurations.Find(id);
            if (configurationUpdate != null)
            {
                configurationUpdate.GiaTri = configuration.GiaTri;
                configurationUpdate.GhiChu = configuration.GhiChu;
                _context.Configurations.Update(configurationUpdate);
                await _context.SaveChangesAsync();
                return configurationUpdate;
            }
            return null;
        }
    }
}