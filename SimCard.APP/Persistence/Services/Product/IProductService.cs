
using System.Collections.Generic;
using System.Threading.Tasks;

using SimCard.APP.ViewModels;

namespace SimCard.APP.Persistence.Services
{
    public interface IProductService
    {
        Task<IEnumerable<ProductViewModel>> GetAll();

        Task<ProductViewModel> GetById(int id);

        Task<bool> Create(ProductViewModel productViewModels);

        Task<bool> Update(ProductViewModel productViewModel);

        Task<bool> Remove(int id);

        Task<bool> IsExisted(string code, int? shopId);
    }
}
