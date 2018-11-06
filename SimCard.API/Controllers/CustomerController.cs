using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;
using OfficeOpenXml;
using System.IO;
using System;

namespace SimCard.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMapper mapper;
        private readonly ICustomerRepository customerRepository;
        private readonly IUnitOfWork unitOfWork;
        public CustomerController(ICustomerRepository customerRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.customerRepository = customerRepository;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        //api/customer
        [HttpGet]
        public async Task<IEnumerable<CustomerResource>> GetAllCustomers()
        {
            var customers = await customerRepository.GetAllCustomers();
            return mapper.Map<IEnumerable<Customer>, IEnumerable<CustomerResource>>(customers);
        }

        //api/customer/id
        [HttpGet("{id}")]
        public async Task<CustomerResource> GetCustomer(int id)
        {
            var customer = await customerRepository.GetCustomer(id);
            return mapper.Map<Customer, CustomerResource>(customer);
        }

        [HttpGet("last")]
        public async Task<int> GetLastIDCustomerRecord()
        {
            var lastIDRecord = await customerRepository.GetLastIDCustomerRecord();
            return lastIDRecord;
        }

        //api/customer/id
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await customerRepository.GetCustomer(id);

            if (customer == null)
                return NotFound();

            customerRepository.Remove(customer);
            await unitOfWork.CompleteAsync();

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
            await customerRepository.AddCustomer(customer);
            await unitOfWork.CompleteAsync();
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
            await customerRepository.UpdateCustomer(id, customer);
            await unitOfWork.CompleteAsync();
            return StatusCode(201);
        }

        [HttpPost("import")]
        public List<Customer> ImportCustomer()
        {
            var fileUploaded = Request.Form.Files[0];
            using (var ms = new MemoryStream())
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
                            var customer = new Customer();

                            customer.Id = Int32.Parse(worksheet.Cells[row, 1].Value.ToString());
                            customer.tenCH = worksheet.Cells[row, 2].Value.ToString();
                            customer.diachiCH = worksheet.Cells[row, 3].Value.ToString();
                            customer.hoTen = worksheet.Cells[row, 4].Value.ToString();
                            customer.sdt1 = worksheet.Cells[row, 5].Value.ToString();
                            customer.sdt2 = worksheet.Cells[row, 6].Value.ToString();
                            customer.maKH = worksheet.Cells[row, 7].Value.ToString();
                            customer.matheTV = worksheet.Cells[row, 8].Value.ToString();
                            customer.tenCongTy = worksheet.Cells[row, 9].Value.ToString();
                            customer.masoThue = worksheet.Cells[row, 10].Value.ToString();
                            customer.diachiHoaDon = worksheet.Cells[row, 11].Value.ToString();
                            customer.nguonDen = worksheet.Cells[row, 12].Value.ToString();
                            customer.ngGioiThieu = worksheet.Cells[row, 13].Value.ToString();
                            customer.email = worksheet.Cells[row, 14].Value.ToString();
                            customer.fb = worksheet.Cells[row, 15].Value.ToString();
                            customer.zalo = worksheet.Cells[row, 16].Value.ToString();
                            customer.ngayDen = DateTime.Parse(worksheet.Cells[row, 17].Value.ToString());
                            customer.ngaySinh = DateTime.Parse(worksheet.Cells[row, 18].Value.ToString());
                            customer.gioiTinh = Boolean.Parse(worksheet.Cells[row, 19].Value.ToString());
                            customerList.Add(customer);
                        }
                        return customerList;
                    }
                }
                catch (Exception ex)
                {
                    var errorEx = ex;
                    return null;
                }
            }
        }
    
    }
}
