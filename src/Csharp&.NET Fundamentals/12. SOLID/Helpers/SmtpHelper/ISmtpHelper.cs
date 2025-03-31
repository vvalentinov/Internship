using System.Net.Mail;

namespace _12._SOLID.Helpers.SmtpHelper;

public interface ISmtpHelper
{
    public SmtpClient GenerateSmtpClient(
        int port,
        bool enableSSL = true);
}
