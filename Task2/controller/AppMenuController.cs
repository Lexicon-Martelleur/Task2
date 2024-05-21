using Task2.view;

namespace Task2.controller;

internal class AppMenuController(AppMenuView view)
{
    public void StartMainMenu()
    {
        view.PrintWelcome();
        bool useMenu = true;
        do
        {
            try
            {
                string menuItem = view.ReadMenuSelection();
                useMenu = HandleMenuSelection(menuItem);
            }
            catch
            {
                useMenu = ContinueMainMenu(HandleInvalidMenuSelection, true);
            }
        } while (useMenu);
    }

    private bool HandleMenuSelection(string menuItem) => menuItem switch
    {
        "0" => ContinueMainMenu(HandleExit, false),
        "1" => ContinueMainMenu(HandleYouthOrRetired, true),
        "2" => ContinueMainMenu(HandlePriceCalculation, true),
        "3" => ContinueMainMenu(HandleRepeatTenTimes, true),
        "4" => ContinueMainMenu(HandleTheThirdWord, true),
        _ => ContinueMainMenu(HandleInvalidMenuSelection, true)
    };

    private bool ContinueMainMenu(Action action, bool exitMenu)
    {
        action();
        return exitMenu;
    }

    private void HandleExit()
    {
        view.PrintGoodBye();
    }

    private void HandleYouthOrRetired()
    {
        throw new NotImplementedException();
    }

    private void HandlePriceCalculation()
    {
        throw new NotImplementedException();
    }

    private void HandleRepeatTenTimes()
    {
        throw new NotImplementedException();
    }

    private void HandleTheThirdWord()
    {
        throw new NotImplementedException();
    }

    private void HandleInvalidMenuSelection()
    {
        view.PrintInvalidMenuSelection();
    }
}
