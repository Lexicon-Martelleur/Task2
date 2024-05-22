using Task2.model;
using Task2.view;

namespace Task2.controller;

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
