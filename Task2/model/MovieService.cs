using Task2.constant;

namespace Task2.model;

/// <summary>
/// A service class used for implementing movie related use cases.
/// </summary>
internal class MovieService(string currencyName)
{
    public string CurrencyName { get; } = currencyName;

    internal MovieTicket CalculatePrice(uint age)
    {
        if (age <= (uint)MovieAgeGroup.CHILD)
        {
            return new MovieTicket(MovieAgePrice.CHILD, MovieAgeGroup.CHILD);
        }
        else if (age <= (uint)MovieAgeGroup.YOUTH)
        {
            return new MovieTicket(MovieAgePrice.YOUTH, MovieAgeGroup.YOUTH);
        }
        else if (age <= (uint)MovieAgeGroup.ADULT)
        {
            return new MovieTicket(MovieAgePrice.ADULT, MovieAgeGroup.ADULT);
        }
        else if (age <= (uint)MovieAgeGroup.SENIOR)
        {
            return new MovieTicket(MovieAgePrice.SENIOR, MovieAgeGroup.SENIOR);
        }
        else
        {
            return new MovieTicket(MovieAgePrice.SENIOR_OLD, MovieAgeGroup.SENIOR_OLD);
        }
    }

    internal double CalculateGroupPrice(List<MovieTicket> tickets)
    {
        return tickets.Aggregate(0d, (sum, next) => sum += next.Price);
    }

    /// <summary>
    /// Check if group is of a valid size.
    /// </summary>
    /// <exception cref="MovieException"></exception>
    internal void IsValidGroupSize(uint groupSize)
    {
        int minGroupSize = 1;
        if (groupSize < minGroupSize)
        {
            throw new MovieException($"Group size {groupSize} is not valid");
        }
    }
}
