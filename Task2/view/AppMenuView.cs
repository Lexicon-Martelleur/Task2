using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task2.view;

internal class AppMenuView
{
    public void PrintWelcome()
    {
        Console.Clear();
        Console.WriteLine($"""

        👨‍💻👨‍💻👨‍💻 Welcome to task 2 menu! 👨‍💻👨‍💻👨‍💻

        """);
    }

    public string ReadMenuSelection()
    {
        Console.WriteLine("""

    Task 2 Menu
    ===========
        (0) Exit menu
        (1) Youth or retired
        (2) Calculate movie price
        (3) Repeat ten times
        (4) The third word
    """);
        Console.Write("Select menu item: ");
        var selectedMenu = Console.ReadLine();
        return GetSelectedMenuItem(selectedMenu ?? "");
    }

    private string GetSelectedMenuItem(string selectedMenu) => selectedMenu switch
    {
        "0" => "0",
        "1" => "1",
        "2" => "2",
        "3" => "3",
        _ => "-1"
    };

    internal void PrintGoodBye()
    {
        Console.WriteLine("""

        👨‍💻👨‍💻👨‍💻 Goodbye from task 2 menu! 👨‍💻👨‍💻👨‍💻

        """);
    }

    internal void PrintInvalidMenuSelection()
    {
        Console.WriteLine("\n⚠️ Not valid menu item");
    }
}
