namespace _16._Structural_Design_Patterns;

public class ColorTextFormatter : ITextFormatter
{
    private readonly ITextFormatter _textFormatter = null!;
    private readonly string _text = string.Empty;

    public ColorTextFormatter(ITextFormatter textFormatter)
    {
        _textFormatter = textFormatter;
    }

    public ColorTextFormatter(string text)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(text);
        _text = text;
    }

    public string Format()
    {
        if (_textFormatter is not null)
        {
            return $"<color>{_textFormatter.Format()}<color>";
        }

        return $"<color>{_text}<color>";
    }
}
