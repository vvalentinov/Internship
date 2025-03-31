namespace _12._SOLID.Notifications;

public abstract class Notification
{
    public required string Sender { get; init; }

    public required string Recipient { get; init; }

    public required string Message { get; init; }

    public abstract void Send();
}
