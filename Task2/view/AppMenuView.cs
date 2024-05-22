using Task2.constant;
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
