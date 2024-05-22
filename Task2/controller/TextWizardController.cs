using Task2.model;
using Task2.view;

namespace Task2.controller;

internal class TextWizardController(TextWizardView view, TextWizardService service)
{
    public void HandleRepeatTenTimes()
    {
        string text = view.ReadTextFromUser();
        string textRepeated = $"({1}) {text}";
        for (int i = 2; i <= 10; i++)
        {
            textRepeated += $" ({i}) {text}";
        }
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
        catch (Exception ex)
        {
            view.WriteGetThirdWordFailure(ex.Message);
            HandleTheThirdWord();
        }
    }
}
