namespace _15._Behavioral_Design_Patterns;

public class OrderNotificationSystem
{
    private readonly List<ISubscriber> _subscribers = [];

    public bool Subscribe(ISubscriber subscriber)
    {
        if (_subscribers.Contains(subscriber) == false)
        {
            _subscribers.Add(subscriber);
            return true;
        }

        return false;
    }

    public bool Unsubscribe(ISubscriber subscriber)
        => _subscribers.Remove(subscriber);

    public void SendNotificationToAll(string notification)
        => _subscribers.ForEach(x => x.ReceiveNotification(notification));

    public void SendNotificationToStaffMembers(string notification)
    {
        foreach (var subscriber in _subscribers)
        {
            if (subscriber is StaffMember staffMember)
            {
                staffMember.ReceiveNotification(notification);
            }
        }
    }

    public void SendNotificationToCustomers(string notification)
    {
        foreach (var subscriber in _subscribers)
        {
            if (subscriber is Customer customer)
            {
                customer.ReceiveNotification(notification);
            }
        }
    }

    public void SendNotificationToSpecificCustomer(
        string notification,
        Customer customer)
    {
        foreach (var subscriber in _subscribers)
        {
            if (subscriber == customer)
            {
                customer.ReceiveNotification(notification);
            }
        }
    }

    public void SendNotificationToSpecificStaffMember(
        string notification,
        StaffMember staffMember)
    {
        foreach (var subscriber in _subscribers)
        {
            if (subscriber == staffMember)
            {
                staffMember.ReceiveNotification(notification);
            }
        }
    }
}
