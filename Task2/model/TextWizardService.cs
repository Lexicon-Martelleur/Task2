namespace Task2.model;

internal class TextWizardService
{
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
            throw new Exception($"Text must be {minWords} words or more");
        }
    }
}
