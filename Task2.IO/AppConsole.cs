using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.IO;

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

    public void WriteLine(string msg, ConsoleColor color)
    {
        System.ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = MapColor(color);
        Console.WriteLine(msg);
        Console.ForegroundColor = original;
    }

    public void Write(string msg, ConsoleColor color)
    {
        System.ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = MapColor(color);
        Console.Write(msg);
        Console.ForegroundColor = original;
    }

    private System.ConsoleColor MapColor(ConsoleColor color) => color switch
    {
        ConsoleColor.CYAN => System.ConsoleColor.Cyan,
        ConsoleColor.RED => System.ConsoleColor.Red,
        _ => System.ConsoleColor.White
    };
}
