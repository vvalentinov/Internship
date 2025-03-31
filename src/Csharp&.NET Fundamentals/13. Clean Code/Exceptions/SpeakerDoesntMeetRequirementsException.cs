namespace _13._Clean_Code.Exceptions;

public class SpeakerDoesntMeetRequirementsException : Exception
{
    public SpeakerDoesntMeetRequirementsException(string message)
        :base(message)
    {
    }

    public SpeakerDoesntMeetRequirementsException(
        string message,
        params object[] args) : base(string.Format(message, args))
    {
    }
}
