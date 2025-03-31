using _12._SOLID.Helpers.SecretsHelper;
using _12._SOLID.Helpers.SmtpHelper;
using _12._SOLID.Notifications;
using Microsoft.Extensions.Configuration;

using static _12._SOLID.Notifications.NotificationsService;

var configurationBuilder = new ConfigurationBuilder();
var configuration = configurationBuilder
    .AddUserSecrets<Program>()
    .Build();

var secretsHelper = new SecretsHelper(configuration);
var smtpClientHelper = new SmtpHelper(secretsHelper);

var emailNotification = new EmailNotification(smtpClientHelper)
{
    Message = "Some message here...",
    Recipient = "dsad",
    Sender = "dsadaf"
};

var smsNotification = new SmsNotification(secretsHelper)
{
    Message = "Some message here...",
    Recipient = "+15558675310",
    Sender = "+14158141829"
};

var pushNotification = new PushNotification(secretsHelper)
{
    Sender = "NotificationSystem",
    Recipient = "Device FCM Token",
    Message = "Some message here..."
};

var notifications = new List<Notification>
{
    emailNotification,
    smsNotification,
    pushNotification,
};

SendNotifications(notifications);