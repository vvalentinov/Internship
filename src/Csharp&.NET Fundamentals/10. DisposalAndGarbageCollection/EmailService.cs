using System.Net;
using System.Net.Mail;

namespace _10._DisposalAndGarbageCollection;

public class EmailService : IDisposable
{
    private readonly SmtpClient _smtpClient;
    private bool _isDisposed;

    public EmailService(string smtp, string username, string password)
    {
        _smtpClient = new SmtpClient(smtp)
        {
            Port = 587,
            Credentials = new NetworkCredential(username, password),
            EnableSsl = true,
        };
    }

    public void SendEmail(
        string fromEmailAddress,
        string toEmailAddress,
        string subject,
        string body)
    {
        var mailMessage = new MailMessage
        {
            From = new MailAddress(fromEmailAddress),
            Subject = subject,
            Body = $"<h1>{body}</h1>",
            IsBodyHtml = true,
        };

        mailMessage.To.Add(toEmailAddress);
        _smtpClient.Send(mailMessage);
    }

    public void Dispose()
    {
        if (_isDisposed == false)
        {
            _smtpClient?.Dispose();
            _isDisposed = true;
        }
    }

}
