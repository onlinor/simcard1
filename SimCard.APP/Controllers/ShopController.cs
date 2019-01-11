using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories._Shop;

namespace SimCard.API.Controllers
{
    public class ShopController : Controller
    {        
        private readonly IMapper mapper;
        private readonly IShopRepository shopRepository;
        private readonly IUnitOfWork unitOfWork;
    
        public ShopController(IShopRepository shopRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {             
            this.shopRepository = shopRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("/api/shops")]
        public async Task<IEnumerable<ShopResource>> GetShops()
        {
            var shops = await shopRepository.GetShops();
            return mapper.Map<IEnumerable<Shop>, IEnumerable<ShopResource>>(shops);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShop(int id)
        {
            var shop = await shopRepository.GetShop(id, includeRelated: false);

            if (shop == null)
                return NotFound();

            shopRepository.Remove(shop);
            await unitOfWork.CompleteAsync();

            return Ok(id);
        }
    }
}