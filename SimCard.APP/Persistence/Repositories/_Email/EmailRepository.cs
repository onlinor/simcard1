using Microsoft.EntityFrameworkCore;

using SimCard.API.Models;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimCard.API.Persistence.Repositories
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
            List<Event> dsEvent = await _context.Events.ToListAsync();
            List<Event> dsEventActive = new List<Event>();
            foreach (Event item in dsEvent)
            {
                // Check 2d before tgBatDau event
                int TotalDay = (item.TgBatDau - DateTime.Now).Days;
                if (item.EventStatus == true && // event is active
                    ((TotalDay == 0 || TotalDay == 1) || (item.TgBatDau < DateTime.Now && DateTime.Now < item.TgKetThuc)) && // event in active time
                    item.IsCompleteEvent == false) // event is not completed. 
                {
                    Event eventUpdate = _context.Events.Find(item.Id);
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
            List<Customer> dsCustomer = await _context.Customers.ToListAsync();
            List<string> dsEmail = new List<string>();
            // var dsEventIsActive = GetListEventActive();
            // foreach (var item in dsEventIsActive.Result) {
            //     if (item.EventStatus == true) {
            //     }
            // }
            // add email to dsEmail
            foreach (Customer item in dsCustomer)
            {
                dsEmail.Add(item.Email);
            }
            return dsEmail;
        }

    }
}