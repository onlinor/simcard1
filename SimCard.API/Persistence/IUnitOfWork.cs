using System.Threading.Tasks;

namespace SimCard.API.Persistence
{
    public interface IUnitOfWork
    {
         Task CompleteAsync();
    }
}