using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Net.Smtp;
using AlDS.Coursework.WebApplicationTest.Models;
using AlDS.Coursework.WebApplicationTest.Configuration;
using AlDS.Coursework.WebApplicationTest.Interfaces;


namespace AlDS.Coursework.WebApplicationTest.Services.Email
{
    public class MailService : IMailService
    {
        private readonly MailSettings _settings;

        public MailService(IOptions<MailSettings> settings)
        {
            _settings = settings.Value;
        }

        public async Task SendEmailAsync(MailRequest mailRequest)
        {
            var email = new MimeMessage();
            email.Sender = MailboxAddress.Parse(_settings.From);
            email.To.Add(MailboxAddress.Parse(mailRequest.ToEmail));
            email.Subject = mailRequest.Subject;
            var builder = new BodyBuilder();

            if (mailRequest.Attachments != null)
            {
                byte[] fileBytes;
                foreach(var file in mailRequest.Attachments)
                {
                    if(file.Length > 0)
                    {
                        using (var ms = new MemoryStream())
                        {
                            file.CopyTo(ms);
                            fileBytes = ms.ToArray();
                        }
                        builder.Attachments.Add(file.FileName, fileBytes, ContentType.Parse(file.ContentType));
                    }
                }
            }
            builder.HtmlBody = mailRequest.Body;
            email.Body = builder.ToMessageBody();

            using (SmtpClient client = new SmtpClient())
            {
                try
                {
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    client.CheckCertificateRevocation = false;

                    await client.ConnectAsync(_settings.Host, _settings.Port, false);
                    await client.AuthenticateAsync(_settings.From, _settings.Password);
                    await client.SendAsync(email);

                    client.Disconnect(true);
                }
                catch (Exception ex)
                {
                    string e = ex.Message;
                }
            }

        }

    }
}
