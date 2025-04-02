namespace _16._Structural_Design_Patterns;

public static class TextFormattingFacade
{
    public static string MakeBold(string input)
        => new BoldTextFormatter(input).Format();

    public static string MakeItalic(string input)
        => new ItalicTextFormatter(input).Format();

    public static string ChangeColor(string input)
        => new ColorTextFormatter(input).Format();

    public static string MakeBoldAndItalic(string input)
        => new BoldTextFormatter(new ItalicTextFormatter(input)).Format();

    public static string ApplyAllFormatters(string input)
        => new BoldTextFormatter(
            new ItalicTextFormatter(
                new ColorTextFormatter(input))).Format();

    public static string RemoveBold(string formattedText)
        => formattedText.Replace("__", string.Empty);

    public static string RemoveItalic(string formattedText)
        => formattedText.Replace("**", string.Empty);

    public static string RemoveColor(string formattedText)
        => formattedText.Replace("<color>", string.Empty);

    public static string RemoveAllFormatting(string formattedText)
    {
        string result = formattedText;
        result = RemoveBold(result);
        result = RemoveItalic(result);
        result = RemoveColor(result);
        return result;
    }
}
