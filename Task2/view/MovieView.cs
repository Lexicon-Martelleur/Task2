using Task2.constant;
using Task2.IO;
using Task2.model;

namespace Task2.view;

/// <summary>
/// A UI class for reading and writing movie related tasks.
/// </summary>
/// <param name="console">
/// A <see cref="AppConsole"/> for IO console operations.
/// </param>
internal class MovieView(AppConsole console)
{
    internal string ReadAgeInput()
    {
        console.Write($"\n➡️ Enter age : ");
        return console.ReadLine();
    }

    internal void PrintMoviePrice(MoviePrice price, string currencyName, bool withIndent = false)
    {
        string prefix = ConstructIndentPrefix(withIndent);
        console.WriteLine($"\n{prefix}✅ {ConstructMoviePriceOutput(price, currencyName)}");
    }

    private string ConstructIndentPrefix(bool withIndent)
    {
        return withIndent ? "\t" : "";
    }

    private string ConstructMoviePriceOutput(MoviePrice price, string currencyName) => price.AgeGroup switch
    {
        MovieAgeGroup.YOUTH => $"Youth price: {price.Price}{currencyName}",
        MovieAgeGroup.SENIOR => $"Senior price: {price.Price}{currencyName}",
        _ => $"Standard price: {price.Price}{currencyName}"
    };

    internal void PrintAgeFailure(string ageInput, bool withIndent = false)
    {
        string prefix = ConstructIndentPrefix(withIndent);
        console.WriteLine($"\n{prefix}⚠️ Age '{ageInput}' is not a valid age", IO.ColorPalette.RED);
    }

    internal string ReadGroupSizeInput()
    {
        console.Write("\n➡️ Enter size of group (use numbers): ");
        return console.ReadLine();
    }

    internal void PrintGroupSizeFailure(string groupSize)
    {
        console.WriteLine($"\n⚠️ Group size '{groupSize}' is not a valid size", IO.ColorPalette.RED);
    }

    internal string ReadAgeInputGroup(int groupItem)
    {
        string prefix = ConstructIndentPrefix(true);
        console.Write($"\n{prefix}➡️ Enter age (person {groupItem}): ");
        return console.ReadLine();
    }

    internal void PrintGroupPrice(double groupPrice, string currencyName)
    {
        console.WriteLine($"\n✅ Price group: {groupPrice}{currencyName}");
    }
}
