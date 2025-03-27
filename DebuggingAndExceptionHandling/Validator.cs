namespace DebuggingAndExceptionHandling;

public class Validator
{
    public static void AgeValidator(int age)
    {
        if (age <= 0)
        {
            throw new ArgumentException("Age cannot be less than or equal to zero!");
        }

        if (age > 120)
        {
            throw new ArgumentException("Age cannot be more than 120!");
        }
    }

    public static void NameValidator(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            throw new ArgumentException("Name cannot ne null or empty!");
        }

        if (name.Length < 2 || name.Length > 750)
        {
            throw new ArgumentException("Name length must be between 2 and 750 characters long!");
        }
    }

    public static void BalanceValidator(decimal balance)
    {
        if (balance < 0)
        {
            throw new NegativeBalanceException("Balance cannot be negative!");
        }
    }
}
