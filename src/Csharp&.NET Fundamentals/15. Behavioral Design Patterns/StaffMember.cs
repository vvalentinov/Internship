namespace _15._Behavioral_Design_Patterns;

public class StaffMember : ISubscriber
{
    public StaffMember(string name)
    {
        Name = name;
    }

    public string Name { get; set; } = string.Empty;

    public void ReceiveNotification(string notification)
    {
        Console.WriteLine($"Staff Member {Name} received notification: {notification}");
    }
}
