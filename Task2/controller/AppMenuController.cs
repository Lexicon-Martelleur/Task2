using Task2.constant;
using Task2.model;
using Task2.view;

namespace Task2.controller;

internal class AppMenuController(
    AppMenuView view,
    MoviePriceService moviePriceService,
    TextService textService)
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
        MainMenu.EXIT => ContinueMainMenu(HandleExit, false),
        MainMenu.PRICE_ONE_PERSON => ContinueMainMenu(HandleGetPriceOnePerson, true),
        MainMenu.PRICE_ONE_GROUP => ContinueMainMenu(HandleGetPriceGroup, true),
        MainMenu.REPEAT_TEN_TIMES => ContinueMainMenu(HandleRepeatTenTimes, true),
        MainMenu.PRINT_THIRD_WORD => ContinueMainMenu(HandleTheThirdWord, true),
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
        Environment.Exit(Environment.ExitCode = 0);
    }

    private void HandleGetPriceOnePerson()
    {
        string ageInput = view.ReadAgeInput();
        try
        {
            int age = int.Parse(ageInput);
            MoviePrice price = moviePriceService.CalculatePrice(age);
            view.PrintMoviePrice(price, moviePriceService.CurrencyName);
        }
        catch
        {
            view.PrintAgeFailure(ageInput);
        }
    }

    private void HandleGetPriceGroup()
    {
        string groupSizeInput = view.ReadGropSizeInput();
        try
        {
            int groupSize = int.Parse(groupSizeInput);
            moviePriceService.IsValidGroupSize(groupSize);
            HandleGetPriceGroup(groupSize);
        }
        catch
        {
            view.PrintGroupSizeFailure(groupSizeInput);
        }
    }

    private void HandleGetPriceGroup(int groupSize)
    {
        List<MoviePrice> moviePrices = [];
        for (int i = 0; i < groupSize; i++)
        {
            MoviePrice price = HandleGetPriceOnePersonInGroup(i + 1);
            moviePrices.Add(price);
        }
        double groupPrice = moviePriceService.CalculateGroupPrice(moviePrices);
        view.PrintGroupPrice(groupPrice, moviePriceService.CurrencyName);
    }

    //TODO! Add quit possibility
    //  1) Incorrect number of people quit and repeat
    //  2) INcorrecet number of people but calculate price
    private MoviePrice HandleGetPriceOnePersonInGroup(int groupItem)
    {
        bool withIndent = true;
        string ageInput = view.ReadAgeInputGroup(groupItem);
        try
        {
            int age = int.Parse(ageInput);
            MoviePrice price = moviePriceService.CalculatePrice(age);
            view.PrintMoviePrice(price, moviePriceService.CurrencyName, withIndent);
            return price;
        } catch
        {
            view.PrintAgeFailure(ageInput, withIndent);
            return HandleGetPriceOnePersonInGroup(groupItem);
        }
    }

    private void HandleRepeatTenTimes()
    {
        string text = view.ReadTextFromUser();
        string textRepeated = $"({1}) {text}";
        for (int i = 2; i <= 10; i++)
        {
            textRepeated += $" ({i}) {text}";
        }
        view.WriteTextLine(textRepeated);
    }

    private void HandleTheThirdWord()
    {
        string text = view.ReadTextFromUser();
        try
        {
            string thirdWord = textService.GetWordThree(text);
            view.WriteTextLine(thirdWord);
        }
        catch (Exception ex)
        {
            view.WriteGetThirdWordFailure(ex.Message);
        }
    }

    private void HandleInvalidMenuSelection()
    {
        view.PrintInvalidMenuSelection();
    }
}
