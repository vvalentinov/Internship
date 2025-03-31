using _12._SOLID.Helpers.SecretsHelper;
using Twilio;
using Twilio.Rest.Api.V2010.Account;

using static _12._SOLID.Constants;

namespace _12._SOLID.Notifications;

public class SmsNotification : Notification
{
    private readonly ISecretsHelper _secretsHelper;

    public SmsNotification(ISecretsHelper secretsHelper)
    {
        _secretsHelper = secretsHelper;
    }

    public override void Send()
    {
        var accountSid = _secretsHelper.GetSecret(TwillioAccountSIDKey, TwillioSectionKey);
        var authToken = _secretsHelper.GetSecret(TwillioAuthTokenKey, TwillioSectionKey);

        TwilioClient.Init(accountSid, authToken);

        MessageResource.Create(
            body: Message,
            from: new Twilio.Types.PhoneNumber(Sender),
            to: new Twilio.Types.PhoneNumber(Recipient));
    }
}
