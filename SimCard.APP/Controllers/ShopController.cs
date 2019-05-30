using System.Collections.Generic;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Database;
using SimCard.APP.Models;
using SimCard.APP.Repository;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ShopController : Controller
    {
        private readonly IShopRepository _shopRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShopController(IShopRepository shopRepository, ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _shopRepository = shopRepository;
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork ?? throw new System.ArgumentNullException(nameof(unitOfWork));
        }

        [HttpPost("/api/shop/add")]
        public async Task<IActionResult> Addshop(ShopViewModel ShopViewModel)
        {
            if (ShopViewModel == null)
            {
                return BadRequest();
            }

            await _shopRepository.AddShop(ShopViewModel);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }

        [HttpGet("/api/shop")]
        public async Task<IEnumerable<ShopViewModel>> GetShops()
        {
            IEnumerable<Shop> shops = await _shopRepository.GetShops();
            return Mapper.Map<IEnumerable<Shop>, IEnumerable<ShopViewModel>>(shops);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            Shop shop = await _shopRepository.GetShop(id, includeRelated: false);

            if (shop == null)
            {
                return NotFound();
            }

            _shopRepository.Remove(shop);
            await _unitOfWork.SaveChangeAsync();

            return Ok(id);
        }
    }
}