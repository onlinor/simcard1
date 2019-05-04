
using SimCard.APP.ViewModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Persistence.Services
{
    public interface IProductExchangeService
    {
        Task<IEnumerable<ProductExchangeViewModel>> GetAll();

        Task<ProductExchangeViewModel> GetById(int id);

        Task<bool> Create(ProductExchangeViewModel productExchangeViewModel);

        Task<bool> Update(ProductExchangeViewModel productExchangeViewModel);

        Task<bool> Remove(int id);

        Task<bool> IsExisted(string code);
    }
}
