using static _16._Structural_Design_Patterns.TextFormattingFacade;

string text = "Hello, World!";

Console.WriteLine("Make it bold!");
text = MakeBold(text);
Console.WriteLine(text);

Console.WriteLine();

Console.WriteLine("Now add italic");
text = MakeItalic(text);
Console.WriteLine(text);

Console.WriteLine();

Console.WriteLine("Now remove the formattings");
text = RemoveAllFormatting(text);
Console.WriteLine(text);

Console.WriteLine();

Console.WriteLine("Now make it bold and italic!");
text = MakeBoldAndItalic(text);
Console.WriteLine(text);

Console.WriteLine();

Console.WriteLine("Now remove only the bold formatting!");
text = RemoveBold(text);
Console.WriteLine(text);

Console.WriteLine();

Console.WriteLine("Now remove only the italic formatting!");
text = RemoveItalic(text);
Console.WriteLine(text);