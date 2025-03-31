// Get Secrets
using _10._DisposalAndGarbageCollection;
using Microsoft.Extensions.Configuration;

var configurationBuilder = new ConfigurationBuilder();

IConfiguration configuration = configurationBuilder
    .AddUserSecrets<Program>()
    .Build();

string smtp = configuration["smtp"];
string fromEmail = configuration["fromEmailAddress"];
string username = configuration["username"];
string password = configuration["password"];

var emailService = new EmailService(smtp ,username, password);

Console.WriteLine("Subscribe to the newsletter by providing your email below:");
Console.Write("Email: ");

string toEmail = Console.ReadLine() ?? string.Empty;
while (string.IsNullOrWhiteSpace(toEmail))
{
    Console.WriteLine("Error! You must provide an email address!");
    Console.Write("Email: ");
    toEmail = Console.ReadLine() ?? string.Empty;
}

emailService.SendEmail(
    fromEmail,
    toEmail,
    "subject",
    "body"
);