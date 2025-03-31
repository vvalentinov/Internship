using _13._Clean_Code.Exceptions;

using static _13._Clean_Code.Constants;
using _13._Clean_Code.Models;
using _13._Clean_Code.Repository;
using _13._Clean_Code.Services;

namespace IoCAssignment.Services;

public class SpeakerService : ISpeakerService
{
    private readonly ISpeakerRepository _speakerRepo;

    public SpeakerService(ISpeakerRepository speakerRepo)
    {
        _speakerRepo = speakerRepo;
    }

    /// <summary>
    /// Registers a speaker and returns the speaker's id.
    /// </summary>
    public int Register(Speaker speaker)
    {
        ValidateSpeakerInfo(
            speaker.FirstName,
            speaker.LastName,
            speaker.Email,
            speaker.Sessions);

        bool meetsMinimumRequirements = MeetsMinimumRequirements(
            speaker.Experience,
            speaker.HasBlog,
            speaker.Certifications.Count,
            speaker.Employer,
            speaker.Email,
            speaker.Browser.Name,
            speaker.Browser.MajorVersion);

        if (meetsMinimumRequirements == false)
        {
            throw new SpeakerDoesntMeetRequirementsException("Speaker doesn't meet our minimal requirements!");
        }

        var sessions = ApproveSessions(speaker.Sessions);

        var hasAtLeastOneApprovedSession = sessions.Any(x => x.Approved);

        if (hasAtLeastOneApprovedSession == false)
        {
            throw new NoSessionsApprovedException("No sessions approved!");
        }

        speaker.RegistrationFee = CalculateRegistrationFee(10);

        speaker.Id = _speakerRepo.AddSpeaker(speaker);

        return speaker.Id;
    }

    private static void ValidateSpeakerInfo(
        string firstName,
        string lastName,
        string email,
        List<Session> sessions)
    {
        if (string.IsNullOrWhiteSpace(firstName))
        {
            throw new ArgumentNullException(nameof(firstName), "First Name is required.");
        }

        if (string.IsNullOrWhiteSpace(lastName))
        {
            throw new ArgumentNullException(nameof(lastName), "Last Name is required.");
        }

        if (string.IsNullOrWhiteSpace(email))
        {
            throw new ArgumentNullException(nameof(email), "Email is required.");
        }

        if (sessions == null || sessions.Count == 0)
        {
            throw new ArgumentException("Can't register speaker with no sessions to present.");
        }
    }

    private static bool MeetsMinimumRequirements(
        int experience,
        bool hasBlog,
        int certificationsCount,
        string employer,
        string email,
        string browserName,
        int browserMajorVersion)
    {
        if (experience > 10 ||
            hasBlog ||
           certificationsCount > 3 ||
            PrestigiousEmployers.Contains(employer))
        {
            return true;
        }

        string emailDomain = email.Split('@').Last();

        if (DisallowedDomains.Contains(emailDomain))
        {
            return false;
        }

        if (browserName == "InternetExplorer" && browserMajorVersion < 9)
        {
            return false;
        }

        return true;
    }

    private static IList<Session> ApproveSessions(IList<Session> speakerSessions)
    {
        foreach (var session in speakerSessions)
        {
            bool isSessionApproved = OutdatedTechnologies
                .Any(tech => session.Title.Contains(tech) ||
                             session.Description.Contains(tech)) == false;

            session.Approved = isSessionApproved;
        }

        return speakerSessions;
    }

    private static int CalculateRegistrationFee(int speakerExperience)
        => speakerExperience switch
            {
                <= 1 => 500,
                >= 2 and <= 3 => 250,
                >= 4 and <= 5 => 100,
                >= 6 and <= 9 => 50,
                _ => 0,
            };
}
