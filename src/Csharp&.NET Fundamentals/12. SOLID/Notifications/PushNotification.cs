using _12._SOLID.Helpers.SecretsHelper;
using FirebaseAdmin;
using FirebaseAdmin.Messaging;
using Google.Apis.Auth.OAuth2;
using static _12._SOLID.Constants;

namespace _12._SOLID.Notifications;

public class PushNotification : Notification
{
    private readonly ISecretsHelper _secretsHelper;

    public PushNotification(ISecretsHelper secretsHelper)
    {
        _secretsHelper = secretsHelper;
    }

    public string Subject { get; set; } = string.Empty;

    public override void Send()
    {
        var firebaseJsonPath = _secretsHelper.GetSecret(
            FirebaseCredentialsPathKey,
            FirebaseSectionKey);

        FirebaseApp.Create(new AppOptions()
        {
            Credential = GoogleCredential.FromFile(firebaseJsonPath)
        });

        var message = new Message()
        {
            Token = Recipient,
            Notification = new FirebaseAdmin.Messaging.Notification
            {
                Title = Subject,
                Body = Message,
            }
        };

        FirebaseMessaging.DefaultInstance.SendAsync(message);
    }
}
