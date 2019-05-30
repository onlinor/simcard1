using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

using AutoMapper;

using Microsoft.AspNetCore.Mvc;

using OfficeOpenXml;

using SimCard.APP.Models;
using SimCard.APP.Persistence;
using SimCard.APP.Persistence.Repositories;
using SimCard.APP.ViewModels;

namespace SimCard.APP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
        }

        //api/customer
        [HttpGet]
        public async Task<IEnumerable<CustomerViewModel>> GetAllCustomers()
        {
            IEnumerable<Customer> customers = await _customerRepository.GetAllCustomers();
            return Mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerViewModel>>(customers);
        }

        //api/customer/id
        [HttpGet("{id}")]
        public async Task<CustomerViewModel> GetCustomer(int id)
        {
            Customer customer = await _customerRepository.GetCustomer(id);
            return Mapper.Map<Customer, CustomerViewModel>(customer);
        }

        [HttpGet("last")]
        public async Task<int> GetLastIDCustomerRecord()
        {
            int lastIDRecord = await _customerRepository.GetLastIDCustomerRecord();
            return lastIDRecord;
        }

        //api/customer/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            Customer customer = await _customerRepository.GetCustomer(id);

            if (customer == null)
            {
                return NotFound();
            }

            _customerRepository.Remove(customer);
            await _unitOfWork.SaveChangeAsync();

            return Ok(id);
        }

        //api/customer
        [HttpPost]
        public async Task<IActionResult> AddCustomer(Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            await _customerRepository.AddCustomer(customer);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }

        //api/customer 
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateCustomer(int id, Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }
            await _customerRepository.UpdateCustomer(id, customer);
            await _unitOfWork.SaveChangeAsync();
            return StatusCode(201);
        }

        [HttpPost("import")]
        public List<Customer> ImportCustomer()
        {
            Microsoft.AspNetCore.Http.IFormFile fileUploaded = Request.Form.Files[0];
            using (MemoryStream ms = new MemoryStream())
            {
                fileUploaded.CopyTo(ms);
                try
                {
                    using (ExcelPackage package = new ExcelPackage(ms))
                    {
                        List<Customer> customerList = new List<Customer>(); // 

                        ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                        int rowCount = worksheet.Dimension.Rows;
                        for (int row = 2; row <= rowCount; row++)
                        {
                            Customer customer = new Customer
                            {
                                Id = int.Parse(worksheet.Cells[row, 1].Value.ToString()),
                                TenCH = worksheet.Cells[row, 2].Value.ToString(),
                                DiachiCH = worksheet.Cells[row, 3].Value.ToString(),
                                HoTen = worksheet.Cells[row, 4].Value.ToString(),
                                Sdt1 = worksheet.Cells[row, 5].Value.ToString(),
                                Sdt2 = worksheet.Cells[row, 6].Value.ToString(),
                                MaKH = worksheet.Cells[row, 7].Value.ToString(),
                                MatheTV = worksheet.Cells[row, 8].Value.ToString(),
                                TenCongTy = worksheet.Cells[row, 9].Value.ToString(),
                                MasoThue = worksheet.Cells[row, 10].Value.ToString(),
                                DiachiHoaDon = worksheet.Cells[row, 11].Value.ToString(),
                                NguonDen = worksheet.Cells[row, 12].Value.ToString(),
                                NgGioiThieu = worksheet.Cells[row, 13].Value.ToString(),
                                Email = worksheet.Cells[row, 14].Value.ToString(),
                                Fb = worksheet.Cells[row, 15].Value.ToString(),
                                Zalo = worksheet.Cells[row, 16].Value.ToString(),
                                NgayDen = DateTime.Parse(worksheet.Cells[row, 17].Value.ToString()),
                                NgaySinh = DateTime.Parse(worksheet.Cells[row, 18].Value.ToString()),
                                GioiTinh = bool.Parse(worksheet.Cells[row, 19].Value.ToString())
                            };
                            customerList.Add(customer);
                        }
                        return customerList;
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
