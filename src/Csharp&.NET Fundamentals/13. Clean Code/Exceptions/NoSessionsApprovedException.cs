namespace _13._Clean_Code.Exceptions;

public class NoSessionsApprovedException : Exception
{
    public NoSessionsApprovedException(string message) : base(message)
    {
    }
}
