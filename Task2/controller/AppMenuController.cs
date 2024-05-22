using Task2.constant;
using Task2.model;
using Task2.view;

namespace Task2.controller;

internal class AppMenuController(
    AppMenuView view,
    MovieController movieController,
    TextWizardController textWizardController
)
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
                useMenu = Continue(HandleInvalidMenuSelection, true);
            }
        } while (useMenu);
    }

    private bool HandleMenuSelection(string menuItem) => menuItem switch
    {
        MainMenu.EXIT => Continue(HandleExit, false),
        MainMenu.PRICE_ONE_PERSON => Continue(movieController.HandleGetPriceOnePerson, true),
        MainMenu.PRICE_ONE_GROUP => Continue(movieController.HandleGetPriceGroup, true),
        MainMenu.REPEAT_TEN_TIMES => Continue(textWizardController.HandleRepeatTenTimes, true),
        MainMenu.PRINT_THIRD_WORD => Continue(textWizardController.HandleTheThirdWord, true),
        _ => Continue(HandleInvalidMenuSelection, true)
    };

    private bool Continue(Action action, bool exitMenu)
    {
        action();
        return exitMenu;
    }

    private void HandleExit()
    {
        view.PrintGoodBye();
        Environment.Exit(Environment.ExitCode = 0);
    }

    private void HandleInvalidMenuSelection()
    {
        view.PrintInvalidMenuSelection();
    }
}
