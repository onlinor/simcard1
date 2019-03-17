using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
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
            var listOfproductresources = new List<ProductResource>();
            foreach (var item in products)
            {
                var productresource = new ProductResource
                {
                    ma = item.Id,
                    ten = item.Name,
                    // soluong = item.Quantity,
                    menhgia = item.Unit
                };
                listOfproductresources.Add(productresource);
            }
            return listOfproductresources;
            // return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        }

        // [HttpGet("/api/warehouse/{id}")]
        // public async Task<WarehouseResource> GetWarehouse (int id)
        // {
        //     var warehouse = await warehouseRepository.GetWarehouse (id, true);
        //     return mapper.Map<Warehouse, WarehouseResource>(warehouse);
        // }

        [HttpPost("/api/product/add")]
        public async Task<IActionResult> AddProduct(ProductResource[] pr )
        {
            foreach (var item in pr)
            {
                var ProductToAdd = new Product
                {
                    Id = item.ma,
                    Name = item.ten,
                    // Quantity = item.soluong,
                    Unit = item.menhgia
                };

                await productRepository.AddProducts(ProductToAdd);
                await unitOfWork.CompleteAsync();
            }
            return Ok();
        }


        [HttpPost("/api/product/import")]
        public List<ImportProduct> ImportProduct()
        {
            var fileUploaded = Request.Form.Files[0];
            using (var ms = new MemoryStream())
            {
                fileUploaded.CopyTo(ms);
                try
                {
                    using (ExcelPackage package = new ExcelPackage(ms))
                    {
                        List<ImportProduct> importProductList = new List<ImportProduct>();

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            var importProduct = new ImportProduct();

                            importProduct.Ten = worksheet.Cells[row, 1].Value.ToString();
                            importProduct.Ma = worksheet.Cells[row, 2].Value.ToString();
                            importProduct.SoLuong = Int32.Parse(worksheet.Cells[row, 3].Value.ToString());
                            importProduct.MenhGia = Decimal.Parse(worksheet.Cells[row, 4].Value.ToString());
                            importProduct.ChietKhau = Decimal.Parse(worksheet.Cells[row, 5].Value.ToString());
                            importProductList.Add(importProduct);
                        }
                        return importProductList;
                    }
                }
                catch (Exception ex)
                {
                    var errorEx = ex;
                    return null;
                }
            }
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