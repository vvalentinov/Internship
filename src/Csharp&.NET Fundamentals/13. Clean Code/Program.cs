using _13._Clean_Code.Exceptions;
using _13._Clean_Code.Models;
using _13._Clean_Code.Repository;
using IoCAssignment.Services;

var speakerRepo = new SpeakerRepository();

var speakerService = new SpeakerService(speakerRepo);

var alice = new Speaker
{
    Id = 1,
    FirstName = "Alice",
    LastName = "Johnson",
    Email = "alice.johnson@example.com",
    Experience = 5,
    HasBlog = true,
    BlogURL = "https://alice-tech-blog.com",
    Browser = new WebBrowser { Name = "Google Chrome", MajorVersion = 15 },
    Certifications = ["AWS Certified", "Azure DevOps Expert"],
    Employer = "Microsoft",
    Sessions =
    [
        new Session
        {
            Title = "Cloud Computing 101",
            Description = "Introduction to AWS and Azure.",
        }
    ]
};

var bob = new Speaker
{
    Id = 1,
    FirstName = "Bob",
    LastName = "Richards",
    Email = "bob.richards@gmail.com",
    Experience = 1,
    HasBlog = false,
    BlogURL = "",
    Browser = new WebBrowser { Name = "InternetExplorer", MajorVersion = 2 },
    Certifications = ["Kubernetes Certified"],
    Employer = "Some Employeer",
    Sessions =
    [
        new Session
        {
            Title = "Kubernetes Deep Dive",
            Description = "Advanced Kubernetes concepts and networking.",
        }
    ]
};

TryToRegister(alice);
TryToRegister(bob);

void TryToRegister(Speaker speaker)
{
    try
    {
        speakerService.Register(speaker);
    }
    catch (ArgumentNullException exception)
    {
        Console.WriteLine($"Error: {exception.Message}");
    }
    catch (SpeakerDoesntMeetRequirementsException exception)
    {
        Console.WriteLine($"Custom Error: {exception.Message}");
    }
    catch (NoSessionsApprovedException exception)
    {
        Console.WriteLine($"Custom Error: {exception.Message}");
    }
    catch (Exception exception)
    {
        Console.WriteLine($"Error: {exception.Message}");
    }
    finally
    {
        Console.WriteLine();
        Console.WriteLine(new string('-', 50));
        var allSpeakers = speakerRepo.GetAllSpeakers();
        allSpeakers.ForEach(Console.WriteLine);
        Console.WriteLine(new string('-', 50));
        Console.WriteLine();
    }
}
