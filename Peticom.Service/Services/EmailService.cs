using System.Net;
using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Peticom.Core.Domain;
using Peticom.Core.Services;

namespace Peticom.Service.Services;

public class EmailService : IEmailService
{
    private string _smtpServer;
    private string _smtpPort;
    private string _smtpUsername;
    private string _smtpPassword;
    
    public EmailService(IConfiguration configuration)
    {
        _smtpServer = configuration[Settings.SmtpServer];
        _smtpPort = configuration[Settings.SmtpPort];
        _smtpUsername = configuration[Settings.SmtpUsername];
        _smtpPassword = configuration[Settings.SmtpPassword];
    }

    public void SendEmail(string from, string to, string subject, string body)
    {
        using (var client = new SmtpClient(_smtpServer, Convert.ToInt32(_smtpPort)))
        {
            client.UseDefaultCredentials = false;
            client.Credentials = new NetworkCredential(_smtpUsername, _smtpPassword);
            client.EnableSsl = true;

            var message = new MailMessage(from, to, subject, body);
            
            client.Send(message);
        }
    }
}