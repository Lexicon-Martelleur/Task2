using Task2.constant;

namespace Task2.model;

internal class MovieService(string currencyName)
{
    public string CurrencyName { get; } = currencyName;

    internal MoviePrice CalculatePrice(uint age)
    {
        if (age < 20)
        {
            return new MoviePrice(80, MoiveAgeGroup.YOUTH);
        }
        else if (age > 64)
        {
            return new MoviePrice(90, MoiveAgeGroup.SENIOR);
        }
        else
        {
            return new MoviePrice(120, MoiveAgeGroup.ADULT);
        }
    }

    internal double CalculateGroupPrice(List<MoviePrice> moviePrices)
    {
        return moviePrices.Aggregate(0d, (sum, next) => sum += next.Price);
    }

    /// <summary>
    /// Check if group is a valid size
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
