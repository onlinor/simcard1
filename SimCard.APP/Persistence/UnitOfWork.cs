using System.Threading.Tasks;

namespace SimCard.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimCardDBContext _context;

        public UnitOfWork(SimCardDBContext context)
        {
            this._context = context;
        }

        public async Task CompleteAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}