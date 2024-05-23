using Task2.model;
using Task2.view;

namespace Task2.controller;

/// <summary>
/// A class for controlling and parsing IO data related to movie tasks.
/// </summary>
/// <param name="view">
/// A <see cref="MovieView"/> used for reading and writing movie tasks.
/// </param>
/// <param name="service">
/// A <see cref="MovieService"/> used for movie related tasks.
/// </param>
internal class MovieController(MovieView view, MovieService service)
{
    internal void HandleGetPriceOnePerson()
    {
        string ageInput = view.ReadAgeInput();
        try
        {
            uint age = uint.Parse(ageInput);
            MovieTicket price = service.CalculatePrice(age);
            view.PrintMoviePrice(price, service.CurrencyName);
        }
        catch
        {
            view.PrintAgeFailure(ageInput);
            HandleGetPriceOnePerson();
        }
    }

    internal void HandleGetPriceGroup()
    {
        string groupSizeInput = view.ReadGroupSizeInput();
        try
        {
            uint groupSize = uint.Parse(groupSizeInput);
            service.IsValidGroupSize(groupSize);
            HandleGetPriceGroup(groupSize);
        }
        catch
        {
            view.PrintGroupSizeFailure(groupSizeInput);
            HandleGetPriceGroup();
        }
    }

    private void HandleGetPriceGroup(uint groupSize)
    {
        List<MovieTicket> movieTickets = [];
        for (int i = 0; i < groupSize; i++)
        {
            MovieTicket price = HandleGetPriceOnePersonInGroup(i + 1);
            movieTickets.Add(price);
        }
        double groupPrice = service.CalculateGroupPrice(movieTickets);
        view.PrintGroupPrice(groupPrice, service.CurrencyName);
    }

    private MovieTicket HandleGetPriceOnePersonInGroup(int groupItem)
    {
        bool withIndent = true;
        string ageInput = view.ReadAgeInputGroup(groupItem);
        try
        {
            uint age = uint.Parse(ageInput);
            MovieTicket ticket = service.CalculatePrice(age);
            view.PrintMoviePrice(ticket, service.CurrencyName, withIndent);
            return ticket;
        }
        catch
        {
            view.PrintAgeFailure(ageInput, withIndent);
            return HandleGetPriceOnePersonInGroup(groupItem);
        }
    }
}
