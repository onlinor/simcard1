using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
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
            var configurationUpdate = _context.Configurations.Find(id);
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