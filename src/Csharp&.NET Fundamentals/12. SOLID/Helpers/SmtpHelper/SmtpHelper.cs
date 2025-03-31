using _12._SOLID.Helpers.SecretsHelper;
using System.Net.Mail;
using System.Net;

using static _12._SOLID.Constants;

namespace _12._SOLID.Helpers.SmtpHelper;

public class SmtpHelper : ISmtpHelper
{
    private readonly ISecretsHelper _secretsHelper;

    public SmtpHelper(ISecretsHelper secretsHelper)
    {
        _secretsHelper = secretsHelper;
    }

    public SmtpClient GenerateSmtpClient(int port, bool enableSSL = true)
    {
        return new SmtpClient(_secretsHelper.GetSecret(
            EmailHostKey,
            EmailSmtpSectionKey))
        {
            Port = port,
            EnableSsl = enableSSL,
            Credentials = new NetworkCredential(
                _secretsHelper.GetSecret(EmailKey, EmailSmtpSectionKey),
                _secretsHelper.GetSecret(EmailPasswordKey, EmailSmtpSectionKey)),
        };
    }
}
