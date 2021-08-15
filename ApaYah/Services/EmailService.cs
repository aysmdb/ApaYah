using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApaYah.Models;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
using MimeKit.Text;

namespace ApaYah.Services
{
    public class EmailService
    {
        private readonly IOptions<Smtp> _smtp;

        public EmailService(IOptions<Smtp> s)
        {
            _smtp = s;
        }

        public void Send(
            string to,
            string from,
            string subject,
            string body
            )
        {
            var email = new MimeMessage();
            email.From.Add(MailboxAddress.Parse(from));
            email.To.Add(MailboxAddress.Parse(to));
            email.Subject = subject;
            email.Body = new TextPart(TextFormat.Html)
            {
                Text = body
            };

            using var smtp = new SmtpClient();
            smtp.Connect(_smtp.Value.Host,
                _smtp.Value.Port,
                SecureSocketOptions.StartTls);
            smtp.Authenticate(_smtp.Value.Username, _smtp.Value.Password);
            smtp.Send(email);
            smtp.Disconnect(true);
        }
    }
}
