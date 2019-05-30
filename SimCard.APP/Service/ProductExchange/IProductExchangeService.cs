
using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.ViewModels;

namespace SimCard.APP.Service
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
