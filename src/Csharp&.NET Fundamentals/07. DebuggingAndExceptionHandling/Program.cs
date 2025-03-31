using DebuggingAndExceptionHandling;

using static DebuggingAndExceptionHandling.Validator;

try
{
    Console.WriteLine("Begin processing transaction...");
    TransactionProcessor.ProcessTransaction(-100);
}
catch (ArgumentException ex)
{
    Console.WriteLine(ex.Message);
}
finally
{
    Console.WriteLine("End of transaction processing.");
}

var emptyName = string.Empty;
var invalidName = "J";

try
{
    Console.WriteLine("Begin validating name...");
    NameValidator(emptyName);
}
catch (ArgumentException exception)
{
    Console.WriteLine("Argument Exception occurred...");
    Console.WriteLine($"Error: {exception.Message}");
}
catch (Exception exception)
{
    Console.WriteLine("Exception occurred...");
    Console.WriteLine($"Error: {exception.Message}");
}
finally
{
    Console.WriteLine("Finished validating name...");
}

try
{
    Console.WriteLine("Begin validating name...");
    NameValidator(invalidName);
}
catch (ArgumentException exception)
{
    Console.WriteLine("Argument Exception occurred...");
    Console.WriteLine($"Error: {exception.Message}");
}
catch (Exception exception)
{
    Console.WriteLine("Exception occurred...");
    Console.WriteLine($"Error: {exception.Message}");
}
finally
{
    Console.WriteLine("Finished validating name...");
}
