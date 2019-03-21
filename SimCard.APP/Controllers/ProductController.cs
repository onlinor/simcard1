using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

using SimCard.APP.Controllers.Resources;
using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        [HttpGet("/api/product")]
        public async Task<IEnumerable<ProductResource>> GetProducts()
        {
            IEnumerable<Product> products = await _productRepository.GetProducts();
            List<ProductResource> productResources = new List<ProductResource>();
            foreach (Product item in products)
            {
                productResources.Add(new ProductResource
                {
                    Id = item.Id,
                    Ten = item.Name,
                    Soluong = item.Quantity,
                    Menhgia = item.Unit
                });
            }
            return productResources;
            // return mapper.Map<IEnumerable<Product>, IEnumerable<ProductResource>>(products);
        }

        // [HttpGet("/api/warehouse/{id}")]
        // public async Task<WarehouseResource> GetWarehouse (int id)
        // {
        //     var warehouse = await warehouseRepository.GetWarehouse (id, true);
        //     return mapper.Map<Warehouse, WarehouseResource>(warehouse);
        // }

        [HttpPost("/api/product/add")]
        public async Task<IActionResult> AddProduct(ProductResource[] pr)
        {
            foreach (ProductResource item in pr)
            {
                await _productRepository.AddProducts(new Product
                {
                    Id = item.Id,
                    Name = item.Ten,
                    Quantity = item.Soluong,
                    Unit = item.Menhgia
                });
                await _unitOfWork.CompleteAsync();
            }
            return Ok();
        }


        [HttpPost("/api/product/import")]
        public List<ImportReceiptProducts> ImportProduct()
        {
            Microsoft.AspNetCore.Http.IFormFile fileUploaded = Request.Form.Files[0];
            using (MemoryStream ms = new MemoryStream())
            {
                fileUploaded.CopyTo(ms);
                try
                {
                    using (ExcelPackage package = new ExcelPackage(ms))
                    {
                        List<ImportReceiptProducts> importProductList = new List<ImportReceiptProducts>();

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            ImportReceiptProducts importProduct = new ImportReceiptProducts
                            {
                                Ten = worksheet.Cells[row, 1].Value.ToString(),
                                Ma = worksheet.Cells[row, 2].Value.ToString(),
                                SoLuong = int.Parse(worksheet.Cells[row, 3].Value.ToString()),
                                MenhGia = decimal.Parse(worksheet.Cells[row, 4].Value.ToString()),
                                ChietKhau = decimal.Parse(worksheet.Cells[row, 5].Value.ToString())
                            };
                            importProductList.Add(importProduct);
                        }
                        return importProductList;
                    }
                }
                catch (Exception ex)
                {
                    Exception errorEx = ex;
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