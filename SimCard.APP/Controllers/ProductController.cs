using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories._Product;

namespace SimCard.API.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public ProductController (IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.productRepository = productRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        [HttpGet("/api/product")]
        public async Task<IEnumerable<ProductResource>> GetProducts()
        {
            var products = await productRepository.GetProducts();
            return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        }

        // [HttpGet("/api/warehouse/{id}")]
        // public async Task<WarehouseResource> GetWarehouse (int id)
        // {
        //     var warehouse = await warehouseRepository.GetWarehouse (id, true);
        //     return mapper.Map<Warehouse, WarehouseResource>(warehouse);
        // }

        [HttpPost("/api/product/add")]
        public async Task<IActionResult> AddProduct(ProductResource pr)
        {
            var ProductToAdd = new Product
            {
                Name = pr.Name,
                Quantity = pr.Quantity,
                Unit = pr.Unit,
                BuyingPrice = pr.Buyingprice,
                ShopId = pr.shopid
            };

            await productRepository.AddProducts(ProductToAdd);
            await unitOfWork.CompleteAsync();

            return Ok();
        }

        // [HttpPut("/api/warehouse/edit/{id}")]
        // public async Task<IActionResult> EditWarehouse (WarehouseResource wh)
        // {
        //     if(await warehouseRepository.IsWarehouseExists(wh.Name.ToLower()))
        //     {
        //         return BadRequest(wh.Name + " already exists!");
        //     }
            
        //     var warehouseToUpdate = new Warehouse
        //     {
        //         Id = wh.Id,
        //         Name = wh.Name.ToLower(),
        //         Note = wh.Note
        //     };

        //     warehouseRepository.Updatewarehouse(warehouseToUpdate);
        //     await unitOfWork.CompleteAsync();
            
        //     return Ok();   
        // }

        // [HttpDelete("/api/warehouse/remove/{id}")]
        // public async Task<IActionResult> RemoveWarehouse (int id)
        // {
        //     var warehouse = await warehouseRepository.GetWarehouse(id, true);

        //     if (warehouse == null)
        //         return NotFound();

        //     warehouseRepository.Remove(warehouse);
        //     await unitOfWork.CompleteAsync();

        //     return Ok();
        // }
    }
}