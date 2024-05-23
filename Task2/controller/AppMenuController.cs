using Task2.constant;
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
        do
        {
            try
            {
                string menuItem = view.ReadMenuSelection();
                HandleMenuSelection(menuItem);
            }
            catch
            {
                HandleInvalidMenuSelection();
            }
        } while (true);
    }

    private void HandleMenuSelection(string menuItem)
    {
        switch (menuItem)
        {
            case MainMenu.EXIT: HandleExit(); break;
            case MainMenu.PRICE_ONE_PERSON: movieController.HandleGetPriceOnePerson(); break;
            case MainMenu.PRICE_ONE_GROUP: movieController.HandleGetPriceGroup(); break;
            case MainMenu.REPEAT_TEN_TIMES: textWizardController.HandleRepeatTenTimes(); break;
            case MainMenu.PRINT_THIRD_WORD: textWizardController.HandleTheThirdWord(); break;
            default: HandleInvalidMenuSelection(); break;
        }
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
