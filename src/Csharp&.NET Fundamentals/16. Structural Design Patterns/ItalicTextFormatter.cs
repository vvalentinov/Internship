namespace _16._Structural_Design_Patterns;

public class ItalicTextFormatter : ITextFormatter
{
    private readonly string _text = string.Empty;
    private readonly ITextFormatter _formatter = null!;

    public ItalicTextFormatter(ITextFormatter formatter)
    {
        _formatter = formatter;
    }

    public ItalicTextFormatter(string text)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        _text = text;
    }

    public string Format()
    {
        if (_formatter is not null)
        {
            return $"**{_formatter.Format()}**";
        }

        return $"**{_text}**";
    }
}
