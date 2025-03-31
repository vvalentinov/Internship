using _12._SOLID.Helpers.SmtpHelper;

namespace _12._SOLID.Notifications;

public class EmailNotification : Notification
{
    private readonly ISmtpHelper _smtpHelper;

    public EmailNotification(ISmtpHelper smtpHelper)
    {
        _smtpHelper = smtpHelper;
    }

    public string Subject { get; set; } = string.Empty;

    public override void Send()
    {
        var client = _smtpHelper.GenerateSmtpClient(port: 587);

        client.Send(
            Sender,
            Recipient,
            Subject,
            Message);
    }
}
