using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.constant;

namespace Task2.model;

internal class MoviePriceService(string currencyName)
{
    public string CurrencyName { get; } = currencyName;

    internal MoviePrice CalculatePrice(int age)
    {
        if (age < 0) {
            throw new ArgumentOutOfRangeException(nameof(age), "Not a valid age");
        }
        else if (age < 20)
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

    internal void IsValidGroupSize()
    {

    }
}
