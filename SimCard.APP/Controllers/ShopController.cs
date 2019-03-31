using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System.Collections.Generic;
using System.Threading.Tasks;

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
            _unitOfWork = unitOfWork;
        }

        [HttpPost("/api/shop/Add")]
        public async Task<IActionResult> Addshop(ShopViewModel shop)
        {
            if (shop == null)
            {
                return BadRequest();
            }
            int CustomerID = await _customerRepository.GetLastIDCustomerRecord();
            shop.Id = CustomerID;
            await _shopRepository.AddShop(shop);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }

        [HttpGet("/api/shops")]
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