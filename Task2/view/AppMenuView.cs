

using System.Diagnostics;
using Task2.constant;
using Task2.model;
using Task2.IO;

namespace Task2.view;

internal class AppMenuView(AppConsole console)
{
    public void PrintWelcome()
    {
        console.ClearScreen();
        console.WriteLine($"""

        👨‍💻👨‍💻👨‍💻 Welcome to task 2 menu! 👨‍💻👨‍💻👨‍💻

        """, IO.ConsoleColor.CYAN);
    }

    public string ReadMenuSelection()
    {
        console.WriteLine("""

    Task 2 Menu
    ===========
        (0) Exit menu
        (1) Get movie price for one person 
        (2) Get movie price for a group 
        (3) Repeat ten times
        (4) The third word
    """, IO.ConsoleColor.CYAN);
        console.Write("Select menu item: ", IO.ConsoleColor.CYAN);
        var selectedMenu = console.ReadLine();
        return GetSelectedMenuItem(selectedMenu);
    }

    private string GetSelectedMenuItem(string selectedMenu) => selectedMenu switch
    {
        MainMenu.EXIT or
        MainMenu.PRICE_ONE_PERSON or
        MainMenu.PRICE_ONE_GROUP or
        MainMenu.REPEAT_TEN_TIMES or
        MainMenu.PRINT_THIRD_WORD => selectedMenu,
        _ => MainMenu.INVALID
    };

    internal string ReadAgeInput()
    {
        console.Write($"\n➡️ Enter age : ");
        return console.ReadLine();
    }

    internal void PrintMoviePrice(MoviePrice price, string currencyName, bool withIndent = false)
    {
        string prefix = ConstructIndentPrefix(withIndent);
        console.WriteLine($"{prefix}{ConstructMoviePriceOutput(price, currencyName)}");
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

    internal void PrintAgeFailure(string ageInput, bool withIndent = false)
    {
        string prefix = ConstructIndentPrefix(withIndent);
        console.WriteLine($"\n{prefix}⚠️ Age '{ageInput}' is not a valid age", IO.ConsoleColor.RED);
    }

    internal string ReadGropSizeInput()
    {
        console.Write("\n➡️ Enter size of group (use numbers): ");
        return console.ReadLine();
    }

    internal void PrintGroupSizeFailure(string groupSize)
    {
        console.WriteLine($"\n⚠️ Group size '{groupSize}' is not a valid size", IO.ConsoleColor.RED);
    }

    internal string ReadAgeInputGroup(int groupItem)
    {
        string prefix = ConstructIndentPrefix(true);
        console.Write($"\n{prefix}➡️ Enter age (person {groupItem}): ");
        return console.ReadLine();
    }

    internal void PrintGroupPrice(double groupPrice, string currencyName)
    {
        console.WriteLine($"\nPrice group: {groupPrice}{currencyName}");
    }

    internal string ReadTextFromUser()
    {
        console.Write("\n➡️ Enter text: ");
        return console.ReadLine();
    }

    internal void WriteTextLine(string text)
    {    
        console.WriteLine(text);   
    }

    internal void WriteGetThirdWordFailure(string msg)
    {
        console.WriteLine($"\n⚠️ {msg}", IO.ConsoleColor.RED);
    }

    internal void PrintInvalidMenuSelection()
    {
        console.WriteLine("\n⚠️ Not valid menu item", IO.ConsoleColor.RED);
    }

    internal void PrintGoodBye()
    {
        console.WriteLine("""

        👨‍💻👨‍💻👨‍💻 Goodbye from task 2 menu! 👨‍💻👨‍💻👨‍💻

        """, IO.ConsoleColor.CYAN);
    }
}
