using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Quartz;
using Quartz.Logging;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace SimCard.APP.Wokers
{
    public class SendUserEmailsJob : IJob
    {
        private static readonly HttpClient client = new HttpClient();
        public class Event
        {
            public int Id { get; set; }

            public string LoaiSK { get; set; }

            public string MaSK { get; set; }

            public string TenSK { get; set; }

            public string NoiDung { get; set; }

            public DateTime NgayTao { get; set; }

            public DateTime TgBatDau { get; set; }

            public DateTime TgKetThuc { get; set; }

            public string DoiTuong { get; set; }

            public Boolean EventStatus { get; set; }

            public Boolean isNewEvent { get; set; }

            public Boolean isCompleteEvent { get; set; }
        }

        public async Task Execute(IJobExecutionContext context)
        {
            var responseEmail = await client.GetStringAsync("http://localhost:5000/api/email");
            var dsEmail = JsonConvert.DeserializeObject<List<String>>(responseEmail);
            var responseEventActive = await client.GetStringAsync("http://localhost:5000/api/email/eventactive");
            var dsEventActive = JsonConvert.DeserializeObject<List<Event>>(responseEventActive);      
            foreach (var eventItem in dsEventActive)
            {
                foreach ( var email in dsEmail)
                {
                    using (var message = new MailMessage("crushssc1996@gmail.com", email.ToString()))
                    {
                        message.Subject = "Khuyến Mãi Event";
                        message.Body = "Su Kien: " + eventItem.TenSK.ToString() + "\n" + "Ma Su Kien: " + eventItem.MaSK.ToString() + "\n" + 
                                        "Tu ngay: " + eventItem.TgBatDau.ToString() + " Den ngay: " + eventItem.TgKetThuc.ToString();
                        using (SmtpClient client = new SmtpClient 
                        {
                            EnableSsl = true,
                            Host = "smtp.gmail.com",
                            Port = 587,
                            Credentials = new NetworkCredential("crushssc1996@gmail.com", "0913175269sang")
                        })
                        {
                            client.Send(message);
                        }
                    }
                }
                
            }
            // Example #1: Write an array of strings to a file.
            // Create a string array that consists of three lines.
            await Task.CompletedTask;
        }
    }
}
