using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace SimCard.API.Controllers
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
            List<ProductResource> listOfproductresources = new List<ProductResource>();
            foreach (Product item in products)
            {
                ProductResource productresource = new ProductResource
                {
                    ma = item.Id,
                    ten = item.Name,
                    soluong = item.Quantity,
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
        public async Task<IActionResult> AddProduct(ProductResource[] pr)
        {
            foreach (ProductResource item in pr)
            {
                Product ProductToAdd = new Product
                {
                    Id = item.ma,
                    Name = item.ten,
                    Quantity = item.soluong,
                    Unit = item.menhgia
                };

                await _productRepository.AddProducts(ProductToAdd);
                await _unitOfWork.CompleteAsync();
            }
            return Ok();
        }


        [HttpPost("/api/product/import")]
        public List<ImportProduct> ImportProduct()
        {
            Microsoft.AspNetCore.Http.IFormFile fileUploaded = Request.Form.Files[0];
            using (MemoryStream ms = new MemoryStream())
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
                            ImportProduct importProduct = new ImportProduct
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