using Newtonsoft.Json;

using Quartz;

using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Mail;
using System.Threading.Tasks;

namespace SimCard.APP.Workers
{
    public class SendUserEmailsJob : IJob
    {
        private static readonly HttpClient _client = new HttpClient();
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

            public bool EventStatus { get; set; }

            public bool IsNewEvent { get; set; }

            public bool IsCompleteEvent { get; set; }
        }

        public async Task Execute(IJobExecutionContext context)
        {
            string responseEmail = await _client.GetStringAsync("http://localhost:25581/api/email");
            List<string> dsEmail = JsonConvert.DeserializeObject<List<string>>(responseEmail);
            string responseEventActive = await _client.GetStringAsync("http://localhost:25581/api/email/eventactive");
            List<Event> dsEventActive = JsonConvert.DeserializeObject<List<Event>>(responseEventActive);
            foreach (Event eventItem in dsEventActive)
            {
                foreach (string email in dsEmail)
                {
                    using (MailMessage message = new MailMessage("crushssc1996@gmail.com", email.ToString()))
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
