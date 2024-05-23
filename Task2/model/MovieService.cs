using Task2.constant;

namespace Task2.model;

/// <summary>
/// A service class used for implementing movie related use cases.
/// </summary>
internal class MovieService(string currencyName)
{
    public string CurrencyName { get; } = currencyName;

    internal MoviePrice CalculatePrice(uint age)
    {
        if (age < 20)
        {
            return new MoviePrice(80, MovieAgeGroup.YOUTH);
        }
        else if (age > 64)
        {
            return new MoviePrice(90, MovieAgeGroup.SENIOR);
        }
        else
        {
            return new MoviePrice(120, MovieAgeGroup.ADULT);
        }
    }

    internal double CalculateGroupPrice(List<MoviePrice> moviePrices)
    {
        return moviePrices.Aggregate(0d, (sum, next) => sum += next.Price);
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
