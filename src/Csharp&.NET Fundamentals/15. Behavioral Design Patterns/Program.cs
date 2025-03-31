using _15._Behavioral_Design_Patterns;

var orderNotificationSystem = new OrderNotificationSystem();

// online customers
var john = new Customer("John");
var adam = new Customer("Adam");

// staff members
var mikeStaff = new StaffMember("Mike");
var roseStaff = new StaffMember("Rose");

// subscribe all of the people to the notification system
orderNotificationSystem.Subscribe(john);
orderNotificationSystem.Subscribe(adam);
orderNotificationSystem.Subscribe(mikeStaff);
orderNotificationSystem.Subscribe(roseStaff);

// John places an order for The Big Bang
Console.WriteLine("Customer John is placing an order...");
await Task.Delay(3000);
john.PlaceOrder(1, "The Big Bang");
Console.WriteLine($"John placed the order for {john.Order.Title}");

Console.WriteLine();

Console.WriteLine("Sending notification to staff members...");

await Task.Delay(3000);

orderNotificationSystem
    .SendNotificationToStaffMembers($"Customer {john.UserName} placed an order for {john.Order.Title}!");

Console.WriteLine();

Console.WriteLine($"Order with id {john.Order.Id} and title {john.Order.Title} is being prepped...");

await Task.Delay(5000);

Console.WriteLine();

orderNotificationSystem.SendNotificationToSpecificCustomer(
    $"Your order {john.Order.Title} is ready for shipping!", john);

Console.WriteLine();

await Task.Delay(3000);

orderNotificationSystem.SendNotificationToSpecificCustomer(
            $"Your order {john.Order.Title} is shipped!", john);

Console.WriteLine();

// unsubscribe john
Console.WriteLine("Unsubscribing john...");
orderNotificationSystem.Unsubscribe(john);

Console.WriteLine();

// John places an order for The History of Automobiles
Console.WriteLine("Customer John is placing an order...");
await Task.Delay(3000);
john.PlaceOrder(1, "The History of Automobiles");
Console.WriteLine($"John placed the order for {john.Order.Title}");

Console.WriteLine();

orderNotificationSystem
    .SendNotificationToStaffMembers($"Customer {john.UserName} placed an order for {john.Order.Title}!");

// john will not receive the following two notifications
// because he is unsubscribed
await Task.Delay(5000);

orderNotificationSystem.SendNotificationToSpecificCustomer(
    $"Your order {john.Order.Title} is ready for shipping!", john);

await Task.Delay(3000);

orderNotificationSystem.SendNotificationToSpecificCustomer(
            $"Your order {john.Order.Title} is shipped!", john);

// Unsubscribe Mike staff member from notification system
orderNotificationSystem.Unsubscribe(mikeStaff);

adam.PlaceOrder(12, "Frankenstein");

orderNotificationSystem
    .SendNotificationToStaffMembers($"Customer {adam.UserName} placed an order for {adam.Order.Title}!");

// now staff member mike will not receive the notification

await Task.Delay(5000);

orderNotificationSystem.SendNotificationToSpecificCustomer(
    $"Your order {adam.Order.Title} is ready for shipping!", adam);

await Task.Delay(3000);

orderNotificationSystem.SendNotificationToSpecificCustomer(
            $"Your order {adam.Order.Title} is shipped!", adam);