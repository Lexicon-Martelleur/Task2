using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.view;

static internal class ConsoleHelper
{
    public static void WriteLineCyan(string msg)
    {
        ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine(msg);
        Console.ForegroundColor = original;
    }

    public static void WriteCyan(string msg)
    {
        ConsoleColor original = Console.ForegroundColor;
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.Write(msg);
        Console.ForegroundColor = original;
    }
}
