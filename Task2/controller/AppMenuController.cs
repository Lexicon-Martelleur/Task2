using Task2.model;
using Task2.view;

namespace Task2.controller;

internal class AppMenuController(
    AppMenuView view,
    MoviePriceService moviePriceService)
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
        "1" => ContinueMainMenu(HandleGetPriceOnePerson, true),
        "2" => ContinueMainMenu(HandleGetPriceGroup, true),
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

    private void HandleGetPriceOnePerson()
    {
        string ageInput = view.ReadAgeInput();
        try
        {
            int age = int.Parse(ageInput);
            MoviePrice price = moviePriceService.CalculateSwePrice(age);
            view.PrintMoviePrice(price);
        }
        catch
        {
            view.PrintReadAgeFailure(ageInput);
        }
    }

    private void HandleGetPriceGroup()
    {
        string groupSizeInput = view.ReadGropSizeInput();
        try
        {

            int groupSize = int.Parse(groupSizeInput);
            List<MoviePrice> moviePrices = [];
            for (int i = 0; i < groupSize; i++)
            {
                MoviePrice price = HandleGetPriceOnePersonInGroup(i + 1);
                moviePrices.Add(price);
            }
            (
                double groupPrice,
                string currencyName
            ) = moviePriceService.CalculateSweGroupPrice(moviePrices);
            view.PrintGroupPrice(groupPrice, currencyName);
        }
        catch
        {
            view.PrintReadAgeFailure(groupSizeInput);
        }
    }

    private MoviePrice HandleGetPriceOnePersonInGroup(int groupItem)
    {
        bool withIndent = true;
        string ageInput = view.ReadAgeInputGroup(groupItem);
        try
        {
            int age = int.Parse(ageInput);
            MoviePrice price = moviePriceService.CalculateSwePrice(age);
            view.PrintMoviePrice(price, withIndent);
            return price;
        } catch
        {
            view.PrintReadAgeFailure(ageInput, withIndent);
            return HandleGetPriceOnePersonInGroup(groupItem);
        }
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
