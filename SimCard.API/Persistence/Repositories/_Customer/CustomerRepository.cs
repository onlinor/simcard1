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
                customerToUpdate.tenCH = customer.tenCH;
                customerToUpdate.diachiCH = customer.diachiCH;
                customerToUpdate.hoTen = customer.hoTen;
                customerToUpdate.sdt1 = customer.sdt1;
                customerToUpdate.sdt2 = customer.sdt2;
                customerToUpdate.maKH = customer.maKH;
                customerToUpdate.matheTV = customer.matheTV;
                customerToUpdate.tenCongTy = customer.tenCongTy;
                customerToUpdate.masoThue = customer.masoThue;
                customerToUpdate.diachiHoaDon = customer.diachiHoaDon;
                customerToUpdate.ngGioiThieu = customer.ngGioiThieu;
                customerToUpdate.nguonDen = customer.nguonDen;
                customerToUpdate.email = customer.email;
                customerToUpdate.fb = customer.fb;
                customerToUpdate.zalo = customer.zalo;
                customerToUpdate.ngayDen = customer.ngayDen;
                customerToUpdate.ngaySinh = customer.ngaySinh;
                customerToUpdate.gioiTinh = customer.gioiTinh;
                context.Customers.Update(customerToUpdate);
                await context.SaveChangesAsync();
                return customerToUpdate;
            }
            return null;
        }

        public async Task<int> GetLastIDCustomerRecord() {
            int lastIDRecord = 0;
            var anyRecord = await context.Customers.AnyAsync();
            if (anyRecord) {
                lastIDRecord = await context.Customers.MaxAsync(x => x.Id);
            }
            return lastIDRecord;
        }
    }
}