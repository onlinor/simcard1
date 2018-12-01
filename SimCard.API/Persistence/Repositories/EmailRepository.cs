using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SimCard.API.Models;

namespace SimCard.API.Persistence.Repositories
{
    public class EmailRepository : IEmailRepository
    {
        private readonly SimCardDBContext context;
        private readonly ICustomerRepository customerRepository;

        public EmailRepository(SimCardDBContext context, ICustomerRepository customerRepository)
        {
            this.context = context;
            this.customerRepository = customerRepository;
        }
        public async Task<List<Event>> GetListEventActive()
        {
            DateTime Today = DateTime.Now;
            var dsEvent = await context.Events.ToListAsync();
            List<Event> dsEventActive = new List<Event>();
            foreach (var item in dsEvent)
            {
                // Check 2d before tgBatDau event
                int TotalDay = (item.TgBatDau - Today).Days;
                if (item.EventStatus == true && // event is active
                    ((TotalDay == 0 || TotalDay == 1) || (item.TgBatDau < Today && Today < item.TgKetThuc)) && // event in active time
                    item.isCompleteEvent == false) // event is not completed. 
                    {
                        var eventUpdate = context.Events.Find(item.Id);
                        eventUpdate.isCompleteEvent = true;
                        context.Events.Update(eventUpdate);
                        context.SaveChanges();
                        dsEventActive.Add(item);
                    }
            }
            return dsEventActive;
        }
        public async Task<List<string>> GetAllEmail()
        {
            var dsCustomer = await context.Customers.ToListAsync();
            List<string> dsEmail = new List<string>();
            // var dsEventIsActive = GetListEventActive();
            // foreach (var item in dsEventIsActive.Result) {
            //     if (item.EventStatus == true) {
            //     }
            // }
            // add email to dsEmail
            foreach (var item in dsCustomer)
            {
                dsEmail.Add(item.email);
            }
            return dsEmail;
        }

    }
}