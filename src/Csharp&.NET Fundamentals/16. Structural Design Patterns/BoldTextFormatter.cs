namespace _16._Structural_Design_Patterns;

public class BoldTextFormatter : ITextFormatter
{
    private readonly string _text = string.Empty;
    private readonly ITextFormatter _formatter = null!;

    public BoldTextFormatter(ITextFormatter formatter)
    {
        _formatter = formatter;
    }

    public BoldTextFormatter(string text)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        _text = text;
    }

    public string Format()
    {
        if (_formatter is not null)
        {
            return $"__{_formatter.Format()}__";
        }

        return $"__{_text}__";
    }
}
