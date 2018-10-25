using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SimCard.API.Controllers.Resources;
using SimCard.API.Models;
using SimCard.API.Persistence;
using SimCard.API.Persistence.Repositories;

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
            // return Ok(customer);
            // return customer;
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

    }
}
