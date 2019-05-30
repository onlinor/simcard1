
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Persistence.Services;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ProductExchangeController : Controller
    {
        private readonly IProductExchangeService _productExchangeService;

        public ProductExchangeController(IProductExchangeService productExchangeService)
        {
            _productExchangeService = productExchangeService;
        }

        [HttpGet("/api/productexchange")]
        public async Task<IEnumerable<ProductExchangeViewModel>> GetProductExchanges()
        {
            return await _productExchangeService.GetAll();
        }

        [HttpGet("/api/productexchange/{id}")]
        public async Task<ProductExchangeViewModel> GetProductExchange(int id)
        {
            return await _productExchangeService.GetById(id);
        }

        [HttpPost("/api/productexchange/add")]
        public async Task<IActionResult> AddProductExchange(ProductExchangeViewModel productExchangeViewModel)
        {
            if (await _productExchangeService.IsExisted(productExchangeViewModel.Ma))
            {
                return BadRequest(productExchangeViewModel.Ma + " already exists!");
            }
            await _productExchangeService.Create(productExchangeViewModel);

            return Ok();
        }

        [HttpPut("/api/productexchange/edit/{id}")]
        public async Task<IActionResult> EditProductExchange(ProductExchangeViewModel productExchangeViewModel)
        {
            await _productExchangeService.Update(productExchangeViewModel);

            return Ok();
        }

        [HttpDelete("/api/productexchange/remove/{id}")]
        public async Task<IActionResult> RemoveProductExchange(int id)
        {
            await _productExchangeService.Remove(id);

            return Ok();
        }
    }
}