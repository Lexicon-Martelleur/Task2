using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Task2.constant;

namespace Task2.model;

internal class MoviePriceService
{
    private readonly string sweCurrencyName = "kr";
    internal MoviePrice CalculateSwePrice(int age)
    {
        if (age < 0) {
            throw new ArgumentOutOfRangeException(nameof(age), "Not a valid age");
        }
        else if (age < 20)
        {
            return new MoviePrice(80, sweCurrencyName, AgeGroup.YOUTH);
        }
        else if (age > 64)
        {
            return new MoviePrice(90, sweCurrencyName, AgeGroup.SENIOR);
        }
        else
        {
            return new MoviePrice(120, sweCurrencyName, AgeGroup.ADULT);
        }
    }

    internal (double groupPrice, string currencyName) CalculateSweGroupPrice(List<MoviePrice> moviePrices)
    {
        return (
            groupPrice: moviePrices.Aggregate(0d, (sum, next) => sum += next.Price),
            currencyName: sweCurrencyName
        );
    }
}
