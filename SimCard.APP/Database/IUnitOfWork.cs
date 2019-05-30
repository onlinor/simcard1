using System.Threading.Tasks;

namespace SimCard.APP.Database
{
    public interface IUnitOfWork
    {
        Task<bool> SaveChangeAsync();
    }
}