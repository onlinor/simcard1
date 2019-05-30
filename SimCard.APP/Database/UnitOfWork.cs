using System.Threading.Tasks;

namespace SimCard.APP.Database
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimCardDBContext _context;

        public UnitOfWork(SimCardDBContext context)
        {
            _context = context;
        }

        public async Task<bool> SaveChangeAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }
    }
}