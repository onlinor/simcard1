using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;

using SimCard.APP.Database;
using SimCard.APP.Models;

namespace SimCard.APP.Repository
{
    public class EmailRepository : IEmailRepository
    {
        private readonly SimCardDBContext _context;
        private readonly ICustomerRepository _customerRepository;

        public EmailRepository(SimCardDBContext context, ICustomerRepository customerRepository)
        {
            _context = context;
            _customerRepository = customerRepository;
        }
        public async Task<List<Event>> GetListEventActive()
        {
            var dsEvent = await _context.Events.ToListAsync();
            var dsEventActive = new List<Event>();
            foreach (var item in dsEvent)
            {
                // Check 2d before tgBatDau event
                var TotalDay = (item.TgBatDau - DateTime.Now).Days;
                if (item.EventStatus == true && // event is active
                    ((TotalDay == 0 || TotalDay == 1) || (item.TgBatDau < DateTime.Now && DateTime.Now < item.TgKetThuc)) && // event in active time
                    item.IsCompleteEvent == false) // event is not completed. 
                {
                    var eventUpdate = _context.Events.Find(item.Id);
                    eventUpdate.IsCompleteEvent = true;
                    _context.Events.Update(eventUpdate);
                    _context.SaveChanges();
                    dsEventActive.Add(item);
                }
            }
            return dsEventActive;
        }
        public async Task<List<string>> GetAllEmail()
        {
            var dsCustomer = await _context.Customers.ToListAsync();
            var dsEmail = new List<string>();

            foreach (var item in dsCustomer)
            {
                dsEmail.Add(item.Email);
            }
            return dsEmail;
        }

    }
}