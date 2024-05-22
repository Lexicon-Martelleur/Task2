using Task2.model;
using Task2.view;

namespace Task2.controller;

internal class MovieController(MovieView view, MovieService service)
{
    internal void HandleGetPriceOnePerson()
    {
        string ageInput = view.ReadAgeInput();
        try
        {
            int age = int.Parse(ageInput);
            MoviePrice price = service.CalculatePrice(age);
            view.PrintMoviePrice(price, service.CurrencyName);
        }
        catch
        {
            view.PrintAgeFailure(ageInput);
        }
    }

    internal void HandleGetPriceGroup()
    {
        string groupSizeInput = view.ReadGroupSizeInput();
        try
        {
            int groupSize = int.Parse(groupSizeInput);
            service.IsValidGroupSize(groupSize);
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
        double groupPrice = service.CalculateGroupPrice(moviePrices);
        view.PrintGroupPrice(groupPrice, service.CurrencyName);
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
            MoviePrice price = service.CalculatePrice(age);
            view.PrintMoviePrice(price, service.CurrencyName, withIndent);
            return price;
        }
        catch
        {
            view.PrintAgeFailure(ageInput, withIndent);
            return HandleGetPriceOnePersonInGroup(groupItem);
        }
    }
}
