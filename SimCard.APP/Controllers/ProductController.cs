
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

using SimCard.APP.Service;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [ApiController]
    public class ProductController : Controller
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet("/api/product")]
        public async Task<IEnumerable<ProductViewModel>> GetProducts()
        {
            return await _productService.GetAll();
        }

        [HttpPost("/api/product/add")]
        public async Task<IActionResult> AddProducts([FromBody] List<ProductViewModel> productViewModels)
        {
            foreach (var product in productViewModels)
            {
                var existed = await _productService.IsExisted(product.Ma, product.ShopId.Value);
                if (existed)
                {
                    await _productService.Update(product);
                }
                else
                {
                    await _productService.Create(product);
                }
            }

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
                            p.loai = worksheet.Cells[row, 1].Value.ToString();
                            p.ten = worksheet.Cells[row, 2].Value.ToString();
                            p.ma = worksheet.Cells[row, 3].Value.ToString();
                            p.soLuong = int.Parse(worksheet.Cells[row, 4].Value.ToString());
                            p.menhGia = decimal.Parse(worksheet.Cells[row, 5].Value.ToString());
                            p.chietKhau = decimal.Parse(worksheet.Cells[row, 6].Value.ToString());
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