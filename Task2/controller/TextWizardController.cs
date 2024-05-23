using Task2.model;
using Task2.view;

namespace Task2.controller;

/// <summary>
/// A class for controlling and parsing IO data related to text wizard tasks.
/// </summary>
/// <param name="view">
/// A <see cref="TextWizardView"/> used for reading and writing text wizard tasks.
/// </param>
/// <param name="service">
/// A <see cref="TextWizardService"/> used for text wizard related tasks.
/// </param>
internal class TextWizardController(TextWizardView view, TextWizardService service)
{
    public void HandleRepeatTenTimes()
    {
        string text = view.ReadTextFromUser();
        string textRepeated = service.GetTextRepeatedly(text, 10);
        view.WriteOkTextLine(textRepeated);
    }

    internal void HandleTheThirdWord()
    {
        string text = view.ReadTextFromUser();
        try
        {
            string thirdWord = service.GetWordThree(text);
            view.WriteOkTextLine(thirdWord);
        }
        catch (TextWizardException ex)
        {
            view.WriteGetThirdWordFailure(ex.Message);
            HandleTheThirdWord();
        }
    }
}
