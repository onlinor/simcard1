using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using SimCard.APP.Controllers.Resources;
using SimCard.APP.Models;
using SimCard.APP.Persistence;

using SimCard.APP.Persistence.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IShopRepository _shopRepository;
        private readonly IUnitOfWork _unitOfWork;

        public ShopController(IShopRepository shopRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _shopRepository = shopRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/shops")]
        public async Task<IEnumerable<ShopResource>> GetShops()
        {
            IEnumerable<Shop> shops = await _shopRepository.GetShops();
            return _mapper.Map<IEnumerable<Shop>, IEnumerable<ShopResource>>(shops);
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
            await _unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}