using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly SimCardDBContext _context;

        public CustomerRepository(SimCardDBContext context)
        {
            this._context = context;
        }
        public async Task<IEnumerable<Customer>> GetAllCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        public async Task<Customer> GetCustomer(int id)
        {
            return await _context.Customers.FirstOrDefaultAsync(x => x.Id == id);
        }

        public void Remove(Customer customer)
        {
            _context.Remove(customer);
        }

        public async Task<Customer> AddCustomer(Customer customer)
        {
            if (customer != null)
            {
                await _context.AddAsync(customer);
                await _context.SaveChangesAsync();
                return customer;
            }
            return null;
        }

        public async Task<Customer> UpdateCustomer(int id, Customer customer)
        {
            Customer customerToUpdate = _context.Customers.Find(id);

            if (customerToUpdate != null)
            {
                customerToUpdate.TenCH = customer.TenCH;
                customerToUpdate.DiachiCH = customer.DiachiCH;
                customerToUpdate.HoTen = customer.HoTen;
                customerToUpdate.Sdt1 = customer.Sdt1;
                customerToUpdate.Sdt2 = customer.Sdt2;
                customerToUpdate.MaKH = customer.MaKH;
                customerToUpdate.MatheTV = customer.MatheTV;
                customerToUpdate.TenCongTy = customer.TenCongTy;
                customerToUpdate.MasoThue = customer.MasoThue;
                customerToUpdate.DiachiHoaDon = customer.DiachiHoaDon;
                customerToUpdate.NgGioiThieu = customer.NgGioiThieu;
                customerToUpdate.NguonDen = customer.NguonDen;
                customerToUpdate.Email = customer.Email;
                customerToUpdate.Fb = customer.Fb;
                customerToUpdate.Zalo = customer.Zalo;
                customerToUpdate.NgayDen = customer.NgayDen;
                customerToUpdate.NgaySinh = customer.NgaySinh;
                customerToUpdate.GioiTinh = customer.GioiTinh;
                _context.Customers.Update(customerToUpdate);
                await _context.SaveChangesAsync();
                return customerToUpdate;
            }
            return null;
        }

        public async Task<int> GetLastIDCustomerRecord()
        {
            int lastIDRecord = 0;
            bool anyRecord = await _context.Customers.AnyAsync();
            if (anyRecord)
            {
                lastIDRecord = await _context.Customers.MaxAsync(x => x.Id);
            }
            return lastIDRecord;
        }
    }
}