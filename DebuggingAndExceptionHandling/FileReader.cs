namespace DebuggingAndExceptionHandling;

public class FileReader
{
    public static int DivideNumberFromFile(string filePath)
    {
        int result = 0;

        try
        {
            Console.WriteLine("Begin processing file...");
            string content = File.ReadAllText(filePath);
            result = 100 / int.Parse(content);
        }
        catch (FileNotFoundException exception)
        {
            Console.WriteLine($"Error: File not found - {exception.Message}");
        }
        catch (FormatException exception)
        {
            Console.WriteLine($"Error: Invalid number format - {exception.Message}");
        }
        catch (DivideByZeroException exception)
        {
            Console.WriteLine($"Error: Division by zero is not allowed - {exception.Message}");
        }
        finally
        {
            Console.WriteLine("Finished processing file.");
        }

        return result;
    }

}
