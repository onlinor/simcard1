using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public ProductController(IProductRepository productRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        [HttpGet("/api/product")]
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return await _productRepository.GetProducts();
        }

        [HttpPost("/api/product/add")]
        public async Task<IActionResult> AddProduct(List<ProductViewModel> productResources)
        {
            await _productRepository.AddProducts(productResources);
            return Ok();
        }

        [HttpPost("/api/product/uploadProductList")]
        public List<ExpandoObject> UploadProductList()
        {
            Microsoft.AspNetCore.Http.IFormFile fileUploaded = Request.Form.Files[0];
            using (MemoryStream ms = new MemoryStream())
            {
                fileUploaded.CopyTo(ms);
                try
                {
                    using (ExcelPackage package = new ExcelPackage(ms))
                    {
                        List<ExpandoObject> importProductList = new List<ExpandoObject>();

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            dynamic p = new ExpandoObject();

                            p.Ten = worksheet.Cells[row, 1].Value.ToString();
                            p.Ma = worksheet.Cells[row, 2].Value.ToString();
                            p.SoLuong = int.Parse(worksheet.Cells[row, 3].Value.ToString());
                            p.MenhGia = decimal.Parse(worksheet.Cells[row, 4].Value.ToString());
                            p.ChietKhau = decimal.Parse(worksheet.Cells[row, 5].Value.ToString());
                            importProductList.Add(p);
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
    }
}