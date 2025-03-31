namespace DebuggingAndExceptionHandling;

public class TransactionProcessor
{
    public static void ProcessTransaction(decimal amount)
    {
        try
        {
            if (amount <= 0)
            {
                throw new ArgumentException("Transaction amount cannot be negative or zero.");
            }

            Console.WriteLine($"Transaction of {amount:C} processed successfully.");
        }
        catch (ArgumentException ex)
        {
            Console.WriteLine($"Error in ProcessTransaction: {ex.Message}");
            throw;
        }
    }
}
