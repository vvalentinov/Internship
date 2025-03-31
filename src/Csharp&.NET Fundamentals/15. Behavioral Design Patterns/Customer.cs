namespace _15._Behavioral_Design_Patterns;

public class Customer : ISubscriber
{
    public Customer(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; } = string.Empty;

    public Order Order { get; set; } = new();

    public void ReceiveNotification(string notification)
        => Console.WriteLine($"Customer {UserName} received notification: {notification}");

    public void PlaceOrder(int orderId, string bookTitle)
    {
        Order = new Order { Id = orderId, Title = bookTitle };
    }
}
