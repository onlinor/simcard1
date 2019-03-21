using System.Threading.Tasks;

namespace SimCard.APP.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}