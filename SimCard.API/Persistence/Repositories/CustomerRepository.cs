using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SimCardDBContext context;
        public CustomerRepository(SimCardDBContext context)
        {
            this.context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Customer customer)
        {
            context.Remove(customer);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                await context.AddAsync(customer);
                await context.SaveChangesAsync();
                return customer;
            }
            return null;
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            var customerToUpdate = context.Customers.Find(id);

            if (customerToUpdate != null)
            {
                customerToUpdate.StoreName = customer.StoreName;
                customerToUpdate.StoreAddress = customer.StoreAddress;
                customerToUpdate.FullName = customer.FullName;
                customerToUpdate.Gender = customer.Gender;
                customerToUpdate.Email = customer.Email;
                customerToUpdate.Birthday = customer.Birthday;
                customerToUpdate.PhoneNumber = customer.PhoneNumber;
                context.Customers.Update(customerToUpdate);
                await context.SaveChangesAsync();
                return customerToUpdate;
            }

            return null;
        }
    }
}