using System.Threading.Tasks;

namespace SimCard.API.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly SimCardDBContext context;

        public UnitOfWork(SimCardDBContext context)
        {
            this.context = context;
        }

        public async Task CompleteAsync()
        {
            await context.SaveChangesAsync();
        }
    }
}