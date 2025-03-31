namespace _12._SOLID.Notifications;

public static class NotificationsService
{
    public static void SendNotification(Notification notification)
    {
        notification.Send();
    }

    public static void SendNotifications(IEnumerable<Notification> notifications)
    {
        foreach (Notification notification in notifications)
        {
            notification.Send();
        }
    }
}
