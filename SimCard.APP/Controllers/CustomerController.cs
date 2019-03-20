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
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _customerRepository = customerRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        //api/customer
        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllCustomers()
        {
            IEnumerable<Customer> customers = await _customerRepository.GetAllCustomers();
            return _mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        }

        //api/customer/id
        [HttpGet("{id}")]
        public async Task<CustomerResource> GetCustomer(int id)
        {
            Customer customer = await _customerRepository.GetCustomer(id);
            return _mapper.Map<Customer, CustomerResource>(customer);
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
            await _unitOfWork.CompleteAsync();

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
            await _unitOfWork.CompleteAsync();
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
            await _unitOfWork.CompleteAsync();
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
                                tenCH = worksheet.Cells[row, 2].Value.ToString(),
                                diachiCH = worksheet.Cells[row, 3].Value.ToString(),
                                hoTen = worksheet.Cells[row, 4].Value.ToString(),
                                sdt1 = worksheet.Cells[row, 5].Value.ToString(),
                                sdt2 = worksheet.Cells[row, 6].Value.ToString(),
                                maKH = worksheet.Cells[row, 7].Value.ToString(),
                                matheTV = worksheet.Cells[row, 8].Value.ToString(),
                                tenCongTy = worksheet.Cells[row, 9].Value.ToString(),
                                masoThue = worksheet.Cells[row, 10].Value.ToString(),
                                diachiHoaDon = worksheet.Cells[row, 11].Value.ToString(),
                                nguonDen = worksheet.Cells[row, 12].Value.ToString(),
                                ngGioiThieu = worksheet.Cells[row, 13].Value.ToString(),
                                email = worksheet.Cells[row, 14].Value.ToString(),
                                fb = worksheet.Cells[row, 15].Value.ToString(),
                                zalo = worksheet.Cells[row, 16].Value.ToString(),
                                ngayDen = DateTime.Parse(worksheet.Cells[row, 17].Value.ToString()),
                                ngaySinh = DateTime.Parse(worksheet.Cells[row, 18].Value.ToString()),
                                gioiTinh = bool.Parse(worksheet.Cells[row, 19].Value.ToString())
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
