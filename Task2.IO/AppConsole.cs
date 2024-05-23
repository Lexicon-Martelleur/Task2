namespace Task2.IO;

/// <summary>
/// A utility class used to wrap console operations
/// used by the application.
/// </summary>
public class AppConsole
{
    public void ClearScreen()
    {
        try { Console.Clear(); } catch { }
    }

    public void WriteLine(string msg)
    {
        Console.WriteLine(msg);
    }

    public void Write(string msg)
    {
        Console.Write(msg);
    }

    public string ReadLine()
    {
        return Console.ReadLine() ?? "";
    }

    public void WriteLine(string msg, ColorPalette color)
    {
        System.ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = MapColor(color);
        Console.WriteLine(msg);
        Console.ForegroundColor = original;
    }

    public void Write(string msg, ColorPalette color)
    {
        System.ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = MapColor(color);
        Console.Write(msg);
        Console.ForegroundColor = original;
    }

    private System.ConsoleColor MapColor(ColorPalette color) => color switch
    {
        ColorPalette.CYAN => System.ConsoleColor.Cyan,
        ColorPalette.RED => System.ConsoleColor.Red,
        _ => System.ConsoleColor.White
    };
}
