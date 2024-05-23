namespace Task2.model;

/// <summary>
/// A service class used for implementing text related use cases.
/// </summary>
internal class TextWizardService
{
    /// <summary>
    /// Return the third word from a text.
    /// </summary>
    /// <exception cref="TextWizardException"></exception>
    internal string GetWordThree(string text)
    {
        int minWords = 3;
        string[] words = text.Split(' ', StringSplitOptions.RemoveEmptyEntries);
        
        if (words.Length >= minWords)
        {
            return words[2];
        }
        else
        {
            throw new TextWizardException($"Text must be {minWords} words or more");
        }
    }

    internal string GetTextRepeatedly(string text, int times)
    {
        string textRepeated = $"({1}) {text}";
        for (int i = 2; i <= times; i++)
        {
            textRepeated += $" ({i}) {text}";
        }
        return textRepeated;
    }
}
