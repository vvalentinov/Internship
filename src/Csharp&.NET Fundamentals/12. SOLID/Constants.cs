namespace _12._SOLID;

public static class Constants
{
    // Email
    public const string EmailSmtpSectionKey = "smtp";
    public const string EmailKey = "email";
    public const string EmailHostKey = "host";
    public const string EmailPasswordKey = "password";

    // SMS
    public const string TwillioSectionKey = "twillio";
    public const string TwillioAccountSIDKey = "accountSID";
    public const string TwillioAuthTokenKey = "authToken";

    // Firebase Push Notification
    public const string FirebaseSectionKey = "firebase";
    public const string FirebaseCredentialsPathKey = "firebaseCredentialsPath";
}
