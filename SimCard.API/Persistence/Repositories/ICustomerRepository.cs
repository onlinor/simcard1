using System.Collections.Generic;
using System.Threading.Tasks;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public interface ICustomerRepository
    {
        Task<IEnumerable<Customer>> GetAllCustomers();
        Task<Customer> GetCustomer(int id);

        Task<Customer> AddCustomer(Customer customer);

        Task<Customer> UpdateCustomer(int id, Customer customer);

        Task<int> GetLastIDCustomerRecord();
        void Remove(Customer customer);

    }
}