

using System.Diagnostics;
using Task2.constant;
using Task2.model;

namespace Task2.view;

internal class AppMenuView()
{
    public void PrintWelcome()
    {
        Console.Clear();
        ConsoleHelper.WriteLineCyan($"""

        👨‍💻👨‍💻👨‍💻 Welcome to task 2 menu! 👨‍💻👨‍💻👨‍💻

        """);
    }

    public string ReadMenuSelection()
    {
        ConsoleHelper.WriteLineCyan("""

    Task 2 Menu
    ===========
        (0) Exit menu
        (1) Get movie price for one person 
        (2) Get movie price for a group 
        (3) Repeat ten times
        (4) The third word
    """);
        ConsoleHelper.WriteCyan("Select menu item: ");
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

    internal string ReadAgeInput()
    {
        Console.Write($"\n➡️ Enter age : ");
        return Console.ReadLine() ?? "";
    }

    internal void PrintMoviePrice(MoviePrice price, string currencyName, bool withIndent = false)
    {
        string prefix = ConstructIndentPrefix(withIndent);
        Console.WriteLine($"{prefix}{ConstructMoviePriceOutput(price, currencyName)}");
    }

    private string ConstructIndentPrefix(bool withIndent)
    {
        return withIndent ? "\t" : "";
    } 

    private string ConstructMoviePriceOutput(MoviePrice price, string currencyName) => price.AgeGroup switch
    {
        MoiveAgeGroup.YOUTH => $"Youth price: {price.Price}{currencyName}",
        MoiveAgeGroup.SENIOR => $"Senior price: {price.Price}{currencyName}",
        _ => $"Standard price: {price.Price}{currencyName}"
    };

    internal void PrintReadAgeFailure(string ageInput, bool withIndent = false)
    {
        string prefix = ConstructIndentPrefix(withIndent);
        Console.WriteLine($"\n{prefix}⚠️ Age '{ageInput}' is not a valid age");
    }

    internal string ReadGropSizeInput()
    {
        Console.Write("\n➡️ Enter size of group (use numbers): ");
        return Console.ReadLine() ?? "";
    }

    internal void PrintReadGroupSizeFailure(string groupSize)
    {
        Console.WriteLine($"\n⚠️ Group size '{groupSize}' is not a valid size");
    }

    internal string ReadAgeInputGroup(int groupItem)
    {
        string prefix = ConstructIndentPrefix(true);
        Console.Write($"\n{prefix}➡️ Enter age (person {groupItem}): ");
        return Console.ReadLine() ?? "";
    }

    internal void PrintGroupPrice(double groupPrice, string currencyName)
    {
        Console.WriteLine($"\nPrice group: {groupPrice}{currencyName}");
    }

    internal void PrintInvalidMenuSelection()
    {
        Console.WriteLine("\n⚠️ Not valid menu item");
    }

    internal void PrintGoodBye()
    {
        ConsoleHelper.WriteLineCyan("""

        👨‍💻👨‍💻👨‍💻 Goodbye from task 2 menu! 👨‍💻👨‍💻👨‍💻

        """);
    }
}
